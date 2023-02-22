public class ResumeGameController : Controller
{
    public override void Execute(object data)
    {
        UIResume resume = GetView<UIResume>();
        resume.StartCount();
    }
}