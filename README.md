# UNFINISHED

一款快节奏 2D 俯视角街机动作游戏：画线闭合圈地，躲避吸尘怪追逐，争夺领地，并用颜料射击改变局势。目标单局时长为 2–3 分钟。

## 项目信息

- 比赛：[thatgamejam #02](https://itch.io/jam/thatgamejam02)
- 引擎：Unity 2022.3.62f3c1
- 目标平台：Windows / macOS
- 游戏默认语言：English
- 当前状态：原型搭建中

## 运行

用 Unity Hub 打开项目根目录，使用上列 Unity 版本；打开 `Assets/_Project/Scenes/SampleScene.unity` 后进入 Play Mode。

## 目录结构

```text
Assets/_Project/
├── Art/          # Sprites、VFX
├── Audio/        # Music、SFX
├── Data/         # ScriptableObject 配置
├── Prefabs/      # Player、Enemies、Gameplay、UI
├── Scenes/       # 菜单与对局场景
├── Scripts/      # Core、Player、Territory、Enemies、Combat、UI
└── UI/           # HUD 与界面资源
```

将圈地判定、敌人追逐、颜料射击和对局计时分别放在对应的 `Scripts` 子目录；可调参数集中放入 `Data`，场景对象组合成 `Prefabs`。

## 比赛备注

比赛主题是音乐。后续确定如何把曲目的情绪变化映射到追逐强度、领地扩张或对局节奏。若使用比赛提供的录音，只能在本次投稿中原样使用；若使用 AI 生成素材，需在投稿说明中披露。
