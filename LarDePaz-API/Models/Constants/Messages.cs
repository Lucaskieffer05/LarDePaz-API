﻿namespace LarDePaz_API.Models.Constants
{
    public class Messages
    {
        public class Error
        {
            public static string Exception()
            {
                return "Ha ocurrido un error inesperado. Por favor, intenta de nuevo.";
            }
            public static string Unauthorized()
            {
                return "No tienes permisos para realizar esta operación.";
            }
            public static string EntityNotFound(string entityName, bool femine = false)
            {
                return entityName + " no encontrad" + (femine ? "a" : "o") + ".";
            }
            public static string EntitiesNotFound(string entitiesName, bool femine = false)
            {
                return "Algun" + (femine ? "a" : "o") + " de l" + (femine ? "a" : "o") + "s " + entitiesName + " no pudo ser encontrad" + (femine ? "a" : "o") + ".";
            }
            public static string EntityWithRelations(string entityName, string relationName, bool entityFemine = false, bool relationFemine = false)
            {
                return (entityFemine ? "La " : "El ") + entityName + " no puede ser eliminad" + (entityFemine ? "a" : "o") + " porque tiene " + relationName + " asociad" + (relationFemine ? "a" : "o") + "s a " + (entityFemine ? "ella" : "él") + ".";
            }
            public static string SaveEntity(string entityName)
            {
                return "Ha ocurrido un error al intentar guardar " + entityName + ". Por favor, intenta de nuevo.";
            }
            public static string FieldsRequired()
            {
                return "Debes ingresar todos los campos obligatorios.";
            }
            public static string FieldsRequired(string[] fields)
            {
                return "Debes ingresar todos los campos obligatorios: " + string.Join(", ", fields);
            }
            public static string FieldRequired(string fieldName)
            {
                return "El campo " + fieldName + " es requerido.";
            }
            public static string FieldGraterThanZero(string fieldName)
            {
                return "El campo " + fieldName + " debe ser mayor a cero.";
            }
            public static string FieldGraterOrEqualThanZero(string fieldName)
            {
                return "El campo " + fieldName + " debe ser mayor o igual a cero.";
            }
            public static string FieldGraterThanMax(string fieldName)
            {
                return "El campo " + fieldName + " debe ser menor a " + int.MaxValue + ".";
            }
            public static string InvalidField(string fieldName)
            {
                return "El campo " + fieldName + " no es válido.";
            }
            public static string UniqueField(string fieldName, string entityName)
            {
                return "Ya existe " + entityName + " con " + fieldName;
            }
            public static string DuplicateEntity(string entity, bool femine = false)
            {
                return "Ya existe un" + (femine ? "a" : "") + " " + entity + " con los datos ingresados.";
            }
            public static string InvalidPassword()
            {
                return "La contraseña debe contener al menos 8 caracteres, una letra mayúscula, una letra minúscula, un número y un caracter especial.";
            }
            public static string InvalidEmail()
            {
                return "El email ingresado no es válido.";
            }
            public static string DuplicateEmail()
            {
                return "El email ingresado ya se encuentra registrado.";
            }
            public static string InvalidLogin()
            {
                return "Email y/o contraseña inválidos.";
            }
            public static string InvalidToken()
            {
                return "El token ingresado no es válido. Por favor, inicia sesión nuevamente.";
            }
            public static string ExpiredToken()
            {
                return "El token ha expirado. Por favor, inicia sesión nuevamente.";
            }
            public static string TokenCreation()
            {
                return "Ha ocurrido un error al intentar crear el token. Por favor, intenta de nuevo.";
            }
            public static string BlockedUser()
            {
                return "El usuario con el que intentas acceder ha sido bloqueado.";
            }
            public static string UserWithoutRole()
            {
                return "El usuario con el que intentas acceder no posee un rol.";
            }
            public static string NotEnoughStock(string productName)
            {
                return "No hay suficiente stock de " + productName + ".";
            }
        }
        public class CRUD
        {
            public static string EntityCreated(string entityName, bool femine = false)
            {
                return entityName + " cread" + (femine ? "a" : "o") + " correctamente.";
            }
            public static string EntityUpdated(string entityName, bool femine = false)
            {
                return entityName + " editad" + (femine ? "a" : "o") + " correctamente.";
            }
            public static string EntitiesUpdated(string entitiesName, bool femine = false)
            {
                return entitiesName + " editad" + (femine ? "as" : "os") + " correctamente.";
            }
            public static string EntityDeleted(string entityName, bool femine = false)
            {
                return entityName + " eliminad" + (femine ? "a" : "o") + " correctamente.";
            }
            public static string EntityDeactivated(string entityName, bool femine = false)
            {
                return entityName + " desactivad" + (femine ? "a" : "o") + " correctamente.";
            }
            public static string EntityActivated(string entityName, bool femine = false)
            {
                return entityName + " activad" + (femine ? "a" : "o") + " correctamente.";
            }
        }
        public class Operations
        {
        }
    }
}
