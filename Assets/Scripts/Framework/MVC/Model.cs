//抽象类
public abstract class Model
{
    //数据模型

    public abstract string Name { get; } //名字标识

    protected void SendEvent(string eventName, object data = null) //发送事件
    {
        MVC.SendEvent(eventName, data);
    }
}