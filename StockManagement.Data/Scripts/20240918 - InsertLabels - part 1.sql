BEGIN TRY
    BEGIN TRANSACTION;

    DELETE FROM Label
    WHERE Id = 'EEDADAC6-C39A-4D81-8C22-5F85C5545304'
    DELETE FROM Label
    WHERE Id = '283AC380-120B-4D98-B444-B54845A0B6E8'
    DELETE FROM Label
    WHERE Id = '93C496B8-E595-4FD6-8D66-3DD6242DB990'

    INSERT INTO Label (Id, SystemName, Value, Language)
    VALUES ('EEDADAC6-C39A-4D81-8C22-5F85C5545304', 'Login.Access', 'Acesso', 1);
    INSERT INTO Label (Id, SystemName, Value, Language)
    VALUES ('283AC380-120B-4D98-B444-B54845A0B6E8', 'Login.Access', 'Access', 2);
    INSERT INTO Label (Id, SystemName, Value, Language)
    VALUES ('93C496B8-E595-4FD6-8D66-3DD6242DB990', 'Login.Access', 'Acceso', 3);


    COMMIT TRANSACTION;
    PRINT 'Transação realizada com sucesso. COMMIT executado.';

END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    PRINT 'Erro encontrado. Transação revertida. ROLLBACK executado.';
END CATCH;