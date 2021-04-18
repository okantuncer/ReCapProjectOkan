using System;
using System.Linq;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;

namespace Core.Aspects.Autofac.Validation
{
    public class EmptyClass
    {
        public class ValidationAspect : MethodInterception
        {
            private Type _validatorType;
            public ValidationAspect(Type validatorType) // attribute olduğu için type olmak zorunda.
            {
                if (!typeof(IValidator).IsAssignableFrom(validatorType))
                {
                    //throw new System.Exception(AspectMessages.WrongValidationType);
                    throw new System.Exception("Bu bir doğrulama sınıfı değil");
                }

                _validatorType = validatorType;
            }
            protected override void OnBefore(IInvocation invocation)  //invocation method demek.
            {
                var validator = (IValidator)Activator.CreateInstance(_validatorType); //reflection. Reflection: bişeylerin çalışm anında yapılmasını sağlar.
                var entityType = _validatorType.BaseType.GetGenericArguments()[0];
                var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
                foreach (var entity in entities)
                {
                    ValidationTool.Validate(validator, entity);
                }
            }
        }
    }
}
