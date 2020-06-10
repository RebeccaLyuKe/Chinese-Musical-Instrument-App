# Chinese-Musical-Instrument-App
Instrument: dulcimer, duxianqin （乐器：扬琴、独弦琴）


# -项目简介-
本项目是基于实时音频合成的民族乐器模拟演奏应用设计，包含扬琴和独弦琴两款移动端App。
外观界面与实现功能请查看[App操作演示视频](https://www.iqiyi.com/v_19rxp6uhz0.html)

该文件夹包含：
1) Unity工程源文件 -- 文件夹 ChineseMusicalInstrument-UnityProject；
2) 完整工程导出的UnityPackage -- ChineseMusicalInstrument.unitypackage；
3) 用于iOS应用构建的Xcode工程项目 -- 文件夹 Xcode Project(iOS Build)；
4) 安卓应用apk -- duxianqinApp_android.apk, yangqinApp_android.apk.
5) 应用说明书 -- 扬琴与独弦琴App说明书.pdf

# -环境配置-
开发环境：Unity 2018.3.19f1

应用安装平台：iOS & Android

# -查看Unity工程-
如果您需要打开查看或者编辑工程，可以通过两种方式：
1) （推荐）新建一个Unity工程，将文件夹中的ChineseMusicalInstrument.unitypackage文件导入（直接将文件拖入Hierarchy，或者选择菜单中的Assets-Import Package-Custom Package导入）
2) （不推荐）直接在Unity中打开工程（File-Open Project，随后添加工程定位到文件夹ChineseMusicalInstrument-UnityProject），请使用Unity 2018打开，不要使用2017或2019版本，可能会出现错误。

# -应用安装方法-
Android平台：直接将两个apk导入移动设备并自行安装即可

iOS平台：
1) 在Mac系统下，确保安装Xcode 11（本人使用版本为11.5）
2) iOS构建项目文件夹名为Xcode Project，分别名为yangqin和duxianqin，对应扬琴和独弦琴；
3) 在两个项目文件夹中找到Unity-iPhone.xcodeproj文件，并使用Xcode打开；
4) 进入Xcode应用的“偏好设置"-Accounts，在Apple IDs中点击左下角的+号，添加自己的Apple ID，确保在Team列表下可以找到自己的账号；
4) 确认填写主界面General分类下的Display Name（应用名）和Bundle Identifier（不可填写默认的com.Company.ProductName），以及Signing&Capabilities中的Team；
5) 确认用于测试的iOS设备与Mac连接；
6) 点击Xcode应用左上角的三角标志运行，等待构建成功后进入iOS设备，发现应用已安装完毕；
7) 进入iOS设备，前往设置-通用-设备管理，并授权开发者App为可信任；
8) 进入应用即可使用，测试应用有效期7天。应用使用方法可参考pdf说明书。


# -音频库-
如果您对本项目中使用的中国民族乐器音频库感兴趣，可以在[百度网盘链接](https://pan.baidu.com/s/1GoPQDVJJrTVcbpsE9H5tNw)(密码:iexh)中下载。音频库来源于中国音乐学院李子晋老师的团队，包含78种中国民族乐器的音频数据，含单音、演奏技法和成曲演奏等。

