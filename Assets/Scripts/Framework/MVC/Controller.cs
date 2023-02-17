using System;

public abstract class Controller
{
    //执行
    public abstract void Execute(object data);

    //获取 Model
    protected T GetModel<T>() where T : Model
    {
        return MVC.GetModel<T>();
    }

    //获取View
    protected T GetView<T>() where T : View
    {
        return MVC.GetView<T>();
    }

    //注册 Model
    protected void RegisterModel(Model model)
    {
        MVC.RegisterModel(model);
    }

    //注册 View
    protected void RegisterView(View view)
    {
        MVC.RegisterView(view);
    }

    //注册 Controller
    protected void RegisterController(string eventName, Type controllerType)
    {
        MVC.RegisterController(eventName, controllerType);
    }
}