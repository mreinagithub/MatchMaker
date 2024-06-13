using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchMaker.TVShow
{
    public static class IJSRuntimeExtensionMethods
    {

        #region EXTENSIONES REEMPLAZADAS POR PAQUETES BLAZORED

        public static ValueTask<object> SetInLocalStorage(this IJSRuntime js, string key, string content)
            => js.InvokeAsync<object>("localStorage.setItem", key, content);

        public static ValueTask<string> GetFromLocalStorage(this IJSRuntime js, string key)
            => js.InvokeAsync<string>("localStorage.getItem", key);

        public static ValueTask<object> RemoveFromLocalStorage(this IJSRuntime js, string key)
            => js.InvokeAsync<object>("localStorage.removeItem", key);
        public static ValueTask<object> SetInSessionStorage(this IJSRuntime js, string key, string content)
           => js.InvokeAsync<object>("sessionStorage.setItem", key, content);

        public static ValueTask<string> GetFromSessionStorage(this IJSRuntime js, string key)
            => js.InvokeAsync<string>("sessionStorage.getItem", key);

        public static ValueTask<object> RemoveFromSessionStorage(this IJSRuntime js, string key)
            => js.InvokeAsync<object>("sessionStorage.removeItem", key);


        #endregion

        #region EXTENSIONES PARA MANEJO DE SIDEBAR

        public async static ValueTask ToggleSideBar(this IJSRuntime js)
            => await js.InvokeVoidAsync("toggleSideBar");
        public async static ValueTask OcultarOverlay(this IJSRuntime js)
            => await js.InvokeVoidAsync("ocultarOverlay");
        public static async ValueTask MostrarGrupoMenu(this IJSRuntime js, string elementId)
           => await js.InvokeVoidAsync("mostrarGrupoMenu", elementId);
        public static async ValueTask ResaltarItemSeleccionado(this IJSRuntime js, string elementId)
          => await js.InvokeVoidAsync("resaltarItemSeleccionado", elementId);
        public static ValueTask<bool> ShowGrupoSideBar(this IJSRuntime js, string key)
           => js.InvokeAsync<bool>("showGrupoSideBar", key);

        #endregion


        public static ValueTask<object> SetInCookie(this IJSRuntime js, string key, string content, int expires = 30)
           => js.InvokeAsync<object>("CookiesSetCustom", key, content, expires);

        public static ValueTask<string> GetFromCookie(this IJSRuntime js, string key)
            => js.InvokeAsync<string>("Cookies.get", key);

        public static ValueTask<object> RemoveFromCookie(this IJSRuntime js, string key)
            => js.InvokeAsync<object>("Cookies.remove", key);

        public static async ValueTask Focus(this IJSRuntime js, string elementId)
            => await js.InvokeVoidAsync("focusElement", elementId);

        public static async ValueTask MostrarModal(this IJSRuntime js, string elementId)
            => await js.InvokeVoidAsync("mostrarModal", elementId);

        public static async ValueTask OcultarModal(this IJSRuntime js, string elementId)
        => await js.InvokeVoidAsync("ocultarModal", elementId);      

        public static async ValueTask IniciarBootstrapSelect(this IJSRuntime js, string elementId)
            => await js.InvokeVoidAsync("initBootstrapSelect", elementId);

        public static async ValueTask ActualizarValorBootstrapSelect(this IJSRuntime js, string elementId, string valor)
          => await js.InvokeVoidAsync("actualizarValorBootstrapSelect", elementId, valor);

        public static async ValueTask SeleccionarValorSelectItem(this IJSRuntime js, string elementId, string valor)
            => await js.InvokeVoidAsync("seleccionarSelectItem", elementId, valor);    

        public static async ValueTask GuardarComo(this IJSRuntime js, string nombreArchivo, byte[] archivo)
            => await js.InvokeVoidAsync("saveAsFile", nombreArchivo, Convert.ToBase64String(archivo));

        public static async ValueTask CambiarTemaAplicacion(this IJSRuntime js, string nuevoTema)
           => await js.InvokeVoidAsync("SetTemaAplication", nuevoTema);


    }
}
