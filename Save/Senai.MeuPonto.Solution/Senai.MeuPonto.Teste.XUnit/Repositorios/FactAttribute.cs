using System;

namespace Senai.MeuPonto.Teste.XUnit.Repositorios
{
    internal class FactAttribute : Attribute
    {

        //
        // Resumo:
        //     Gets the name of the test to be used when the test is skipped. Defaults to null,
        //     which will cause the fully qualified test name to be used.
        public virtual string DisplayName { get; set; }
        //
        // Resumo:
        //     Marks the test so that it will not be run, and gets or sets the skip reason
        public virtual string Skip { get; set; }
    }
}