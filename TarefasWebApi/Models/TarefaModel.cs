﻿using System.ComponentModel.DataAnnotations;

namespace TarefasWebApi.Models
{
    public class TarefaModel
    {
        [Key]
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public int Status { get; set; }

        public UsuarioModel Usuario { get; set; }

    }
}
