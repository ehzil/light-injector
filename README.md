light-injector
==============

easy/light injector

需要使用容器和注入对象的项目引用LightInjector.Annotations.dll，在需要被容器管理的类上面添加特性[Component]，在需要注入的地方的添加特性[Autowired]，比如：

[Component]

public class Dao
{
    
    public .......

}

public class Service
{
    
    [Autowired]
    private Dao dao;

}

如果使用mvc的话，在web项目中添加LightInjector.Mvc.dll和LightInjector.Core.dll引用，然后在Global.asax.cs的Application_Start中最后一行添加ControllerBuilder.Current.SetControllerFactory(new LightInjectorControllerFactory());
