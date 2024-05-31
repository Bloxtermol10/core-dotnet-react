using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Core.ORM.Helpers
{
    public static class ValidationHelper
    {
        public static bool ValidateProperties<T>(ActionType actionType, T entity, ModelStateDictionary modelState, params string[] requiredProperties)
        {
            foreach (var propName in requiredProperties)
            {
                var propValue = typeof(T).GetProperty(propName)?.GetValue(entity);

                if (string.IsNullOrEmpty(propValue?.ToString()))
                {
                    modelState.AddModelError(propName, $"La propiedad '{propName}' es obligatoria para la acción '{actionType}'.");
                    return false;
                }
            }

            return true;
        }
        public enum ActionType
        {
            Create,
            Update
        }
    }

}
