﻿using Blazor.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Blazor.Pages.MiLaboratorio
{
    public partial class EnvioMuestras
    {
        [Inject] private IExamenServicio examenServicio { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        private Examen examen = new Examen();
        private IEnumerable<Examen> lista { get; set; }
        string IdClien;
        protected override async Task OnInitializedAsync()
        {
            lista = await examenServicio.GetListaPorEstadoAsync("Tomada");
        }

        private async void BuscarP()
        {
            lista = await examenServicio.GetListaPorEstadoYIdPersonaAsync("Tomada", IdClien);
        }

        private async void Todos()
        {
            lista = await examenServicio.GetListaPorEstadoAsync("Tomada");
            IdClien = string.Empty;
        }
    }
}

