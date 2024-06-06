﻿using System.ComponentModel;

namespace TarefasWebApi.Enums
{
    public enum TarefaSatusEnum
    {
        [Description("A fazer")]
        AFazer = 1,
        [Description("Em andamento")]
        EmAndamento = 2,
        [Description("Concluído")]
        Concluido = 3
    }
}
