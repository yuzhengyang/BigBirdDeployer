# Oreo.BigBirdDeployer
Java Web项目启动工具，版本控制工具，方便服务器发布Java服务，查看输出控制台信息，控制Java服务的版本，方便回退版本。

### 一、起因
最近开发Java Web项目，开发完后需要打包发布，因为项目分成了微服务，所以要运行的服务比较多，在服务器上就是这种样子，如图：

![image](https://github.com/yuzhengyang/Oreo.BigBirdDeployer/blob/master/Documents/ScreenShot/2018725103904.png?raw=true)

这样不方便管理，停止服务的时候很容易搞错，造成一些误操作。

因为只需要执行一句java -jar，所以就用C#写了一个Java Web发布的管理程序。

### 二、现状
目前支持的功能有：
1. Java Web 启动/关闭
2. 项目的版本控制
3. 控制台输出
4. CPU和RAM的占用情况

截图如下：

![image](https://github.com/yuzhengyang/Oreo.BigBirdDeployer/blob/master/Documents/ScreenShot/2018725104118.png?raw=true)

### 三、使用
使用的话可以参考：
[使用说明书](https://github.com/yuzhengyang/Oreo.BigBirdDeployer/blob/master/Documents/BigBirdDeployer_Instructions.pdf)