function closeModal(modalId) {
    var modalElement = document.getElementById(modalId);
    var modal = bootstrap.Modal.getInstance(modalElement);

    if (!modal) {
        modal = new bootstrap.Modal(modalElement);
    }

    modal.hide();
}