using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace FullerHelpers
{
    public static class ModelConverter
    {
        public static T ConvertToModel<T>(Object source) where T : new()
        {
            Type inputType = source.GetType();
            Type inputBaseType = inputType.BaseType;

            Type outputType = typeof(T);
            Type outputBaseType = outputType.BaseType;

            bool IsInputArray = inputBaseType == typeof(Array) ? true : false;
            bool IsOutputArray = outputBaseType == typeof(Array) ? true : false;

            bool IsInputCollection = inputType.IsGenericType == true ? (inputType.GetGenericTypeDefinition() == typeof(List<>) ? true : false) : false;
            bool IsOutputCollection = outputType.IsGenericType == true ? (outputType.GetGenericTypeDefinition() == typeof(List<>) ? true : false) : false;

            if (IsInputArray == true)
            {
                inputType = ((Array)source).GetType().GetElementType();
            }
            else if (IsInputCollection == true)
            {
                inputType = ((List<T>)source).GetType().GetGenericArguments().Single();
            }

            if (IsOutputArray == true)
            {

            }
            else if (IsOutputCollection == true)
            {

            }

            if (IsValidConversion(inputType, outputType) == true)
            {
                //Continue with conversion
                return (T)Mapper.Map(source, source.GetType(), typeof(T));
            }
            else
            {
                //Throw exception
                throw new InvalidCastException(String.Format("Cannot convert item of type {0} to item of type {1}", inputType.ToString(), outputType.ToString()));
            }
        }

        private static bool IsValidConversion(Type input, Type output)
        {
            var mapTypes = Mapper.GetAllTypeMaps();
            var findCount = (from m in mapTypes where m.SourceType == input && m.DestinationType == output select m).Count();
            findCount = 1;
            if (findCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
