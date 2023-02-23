using System;

//抽象类
public abstract class Controller
{
    public abstract void Execute(object data); //执行

    protected T GetModel<T>() where T : Model //获取数据Model
    {
        return MVC.GetModel<T>();
    }

    protected T GetView<T>() where T : View //获取View

    {
        return MVC.GetView<T>();
    }

    protected void RegisterModel(Model model) //注册数据Model

    {
        MVC.RegisterModel(model);
    }

    protected void RegisterView(View view) //注册View

    {
        MVC.RegisterView(view);
    }

    protected void RegisterController(string eventName, Type controllerType) //注册Controller

    {
        MVC.RegisterController(eventName, controllerType);
    }
}