# EzAsWeapon
A generator for Sven-Coop scripts weapons

>     LET US REMEMBER, PLEASE, THAT THE SEARCH FOR THE CONSTITUTION
>     OF THE WORLD IS ONE OF THE GREATEST AND NOBLEST PROBLEMS PRESENTED 
>     BY NATURE.
> 
>                                                        -- GALILEO

----

一个简单的Sven-Coop武器模版生成工具

基于之前写的👉baseweapon.as

依旧是菜鸡学习C井的垃圾作品

不过这个有BUG可以***维护***

不知道什么是As脚🦶🏿本？

: 戳[这里](https://github.com/baso88/SC_AngelScript/wiki)去看

使用方法
----
- **双击打开**
   - 打开菜单，输出baseweapon.as到任意位置，文件名必须为baseweapon.as
   - 正确输入你的数据，点击右下输出按钮导出脚本和baseweapon.as一样位置
      - （为了保证后续步骤方便，建议和武器名使用一样的名字）
   - 打开菜单，选择Register生成器
   - 填入你刚才制作的所有武器的注册名和文件名，选择你baseweapon.as和生成的脚本在svencoop里的位置，并且选择即将生成的Register的位置，如果在costum_weapons和plugin文件夹可留空
   - 生成，文件名随意
- **关闭程序**
   - 将刚生成的baseweapon.as和脚本，以及Register.as放到你刚设置的位置
   - 用文本编辑器（记事本📝啦）打开svencoop/default_plugin.txt,并添加以下内容到文件最后
```
     	"plugin"
	{
		"name" EzWeaponRegister
		"script" 你自己写的路径，你自己取的名字
	}
```

   - 关掉📝.exe
- **打开λ，enjoy🤗**

__不知道怎么在游戏里拿出自定义武器？最简单的👇__

`打开控制台，输入sv_cheats 3, 再give weapon_balabalabala`
***

👉[下载](https://github.com/DrAbcrealone/EzAsWeapon/releases)

---
```
    void PluginInit()
    {
       g_Module.ScriptInfo.SetAuthor("Dr.Abc")
       后面不会了
```
***
以上👆
