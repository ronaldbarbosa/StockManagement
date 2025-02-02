﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using StockManagement.Application.DTOs;
using StockManagement.Application.DTOs.Request;
using StockManagement.Application.DTOs.Response;
using StockManagement.BlazorWebApp.Authentication;
using StockManagement.BlazorWebApp.Services.Interfaces;
using System.Net.Http.Json;

namespace StockManagement.BlazorWebApp.Pages.User
{
    public partial class Profile : ComponentBase
    {
        #region services
        [Inject]
        public IBlobStorageWebService BlobStorageWebService { get; set; } = null!;

        [Inject]
        public IUserWebService AuthWebService { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ICustomAuthenticationStateProvider AuthStateProvider { get; set; } = null!;
        #endregion

        #region properties
        public IBrowserFile? SelectedFile { get; set; }

        public string UploadResult { get; set; } = string.Empty;

        public bool Loading { get; set; } = false;

        public UserDTO User { get; set; } = new UserDTO();

        public UpdateUserAccessRequest UserAccess { get; set; } = new UpdateUserAccessRequest();

        public List<string> Errors { get; set; } = [];

        public bool HasAlertMessage { get; set; } = false;

        public ErrorArea ErrorArea { get; set; } 
        #endregion

        #region overrides

        protected override async Task OnInitializedAsync()
        {
            var result = await AuthWebService.GetUserInfoAsync();
            if (result is not null)
            {
                User = result.User ?? new UserDTO();
            }
        }

        #endregion

        #region methods

        public void HandleFile(InputFileChangeEventArgs e)
        {
            SelectedFile = e.File;
        }

        public async Task UploadFile()
        {
            Loading = true;

            if (SelectedFile is null)
            {
                Loading = false;
                return;
            }

            var content = new MultipartFormDataContent();
            var fileContent = new StreamContent(SelectedFile.OpenReadStream(maxAllowedSize: 1024 * 1024 * 4));

            content.Add(fileContent, "file", SelectedFile.Name);

            var response = await BlobStorageWebService.UploadImageAsync(content);

            if (response.IsSuccessStatusCode)
            {
                var avatarUrl = await response.Content.ReadFromJsonAsync<ImageUploadResponse>();
                User.AvatarUrl = avatarUrl!.Url;
                await OnValidSubmitAsync();
                UploadResult = "Sucesso";
            }
            else
            {
                UploadResult = "Erro" + response.ReasonPhrase;
            }

            Loading = false;
        }

        public async Task OnValidSubmitAsync()
        {
            Loading = true;
            Errors = [];
            HasAlertMessage = false;

            try
            {
                var result = await AuthWebService.UpdateUserInfoAsync(User);

                if (result.IsSucceded())
                {
                    HasAlertMessage = true;                    
                }
                else
                {
                    if (result.Errors.Count != 0)
                    {
                        foreach (var errorList in result.Errors.Keys)
                        {
                            Errors.Add(errorList);
                        }
                        ErrorArea = ErrorArea.ProfileInfo;
                    }
                }
            }
            catch (Exception ex)
            {
                Errors.Add(CommonLocalizer["CommonError"]);
                ErrorArea = ErrorArea.ProfileInfo;
            }

            Loading = false;
        }

        public async Task UpdateUserAccessInfo()
        {
            Loading = true;
            Errors = [];
            HasAlertMessage = false;

            try
            {
                UserAccess.NewEmail = User.Email;
                var result = await AuthWebService.UpdateUserAccessAsync(UserAccess);

                if (result.IsSucceded())
                {
                    HasAlertMessage = true;
                    await JS.InvokeVoidAsync("closeModal", "modal-update-password");
                }
                else
                {
                    if (result.Errors.Count != 0)
                    {
                        foreach (var errorList in result.Errors.Keys)
                        {
                            Errors.Add(errorList);
                        }

                        ErrorArea = ErrorArea.UpdatePasswordModal;
                    }
                }
            }
            catch (Exception ex)
            {
                Errors.Add(CommonLocalizer["CommonError"]);
                ErrorArea = ErrorArea.UpdatePasswordModal;
            }

            Loading = false;
        }

        public void RedirectToLogin()
        {
            NavigationManager.NavigateTo("/Login");
        }
        #endregion        
    }

    #region enums

    public enum ErrorArea
    {
        ProfileInfo,
        UpdatePasswordModal
    }

    #endregion
}