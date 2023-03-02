//对象池接口

public interface IReusable
{
    //取出
    void OnSpawn();

    //回收
    void OnUnSpawn();
}