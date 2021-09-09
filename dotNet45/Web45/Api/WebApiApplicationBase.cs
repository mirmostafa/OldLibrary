namespace Mohammad.Web.Api {
    public abstract class WebApiApplicationBase<TApplication> : WebApiConfigBase<TApplication>
        where TApplication : WebApiConfigBase<TApplication> { }
}