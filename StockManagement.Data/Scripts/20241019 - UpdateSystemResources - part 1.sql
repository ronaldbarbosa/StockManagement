BEGIN TRY
    BEGIN TRANSACTION;

    UPDATE SystemResource
    SET Icon = 'fa-user-shield', Path = 'administracao'
    WHERE Id = 'A1169D53-714A-4E0B-A34B-4E277C42B554'

    UPDATE SystemResource
    SET Icon = 'fa-address-card', Path = 'administracao/cargos'
    WHERE Id = 'C6BD1069-05D4-44BA-9757-FDB89BA279DA'


    COMMIT TRANSACTION;
    PRINT 'Transação realizada com sucesso. COMMIT executado.';

END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    PRINT 'Erro encontrado. Transação revertida. ROLLBACK executado.';
END CATCH;