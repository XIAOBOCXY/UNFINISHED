# UNFINISHED

《UNFINISHED》是一款 2D 俯视角无限街机 Roguelite。玩家在单张竞技场中自由画线圈地、捕获吸尘怪并留下永久印章，通过卡牌构筑挑战更高 Wave、Canvas 数量与分数。

## 项目信息

- 比赛：[thatgamejam #02](https://itch.io/jam/thatgamejam02)
- 引擎：Unity 2022.3.62f3c1
- 目标平台：Windows（优先）
- 游戏默认语言：English
- 当前状态：原型搭建中

## 核心规则

- 从 0% 覆盖率开始；Canvas 达到 70% 时完成并重置，获得 +90 秒、+6 Ink、+2000 Score。时间上限为 240 秒。
- WASD 移动，鼠标瞄准，鼠标左键射击；进入空白区域自动绘制湿颜料线。
- 连接安全领地或锚点，或与自身轨迹形成有效闭合后，每次只填充一个区域。一次动作产生多个候选时，结算最先形成的有效闭合区域并结束绘画；其余未闭合尾线清除。障碍和地图边缘不能代替闭合。
- 捕获区内的吸尘怪会留下印章并提供奖励。印章只能保护已经占领的区域。
- 湿线被吸断时，本次绘画取消，玩家返回最近的安全位置并获得 0.6 秒保护；没有生命值。
- 每 60 秒实际战斗时间推进一波并开启商店；每波获得 5 Ink，每次商店最多购买两张卡牌。
- 倒计时归零时结束本局。目标是提高 Score、Wave 和完成的 Canvas 数量。

## 运行

用 Unity Hub 打开项目根目录，使用上列 Unity 版本；打开 `Assets/_Project/Scenes/SampleScene.unity` 并进入 Play Mode。

## 目录结构

```text
Assets/_Project/
├── Art/          # Sprites、VFX
├── Audio/        # Music、SFX
├── Data/         # Arena、Cards、Balance 配置
├── Prefabs/      # Player、Enemies、Gameplay、UI
├── Scenes/       # 菜单与对局场景
├── Scripts/      # 按游戏系统划分的 C# 代码
└── UI/           # HUD 与界面资源
```

### 脚本模块

- `Core`：对局状态、统一时钟、暂停与系统协调。
- `Player`、`Combat`：玩家输入/移动、瞄准与颜料射击。
- `Territory`：湿线记录、闭合检测、Mask 填色、覆盖率与印章保护。
- `World`、`Enemies`：竞技场与障碍、吸尘怪 AI、擦除和刷新控制。
- `Progression`：Canvas、Wave、Ink、卡牌、商店、Fever 与 Score。
- `UI`、`Audio`：界面流程、音乐与音效。

配置数据放在 `Data`，场景对象组合成 `Prefabs`。Canvas 和 Wave 各自管理进度；`Core` 负责协调暂停、完成结算和系统间的事件顺序，避免把所有规则堆进单一 GameManager。

## 比赛备注

比赛主题是音乐。可将音乐层次与 Fever、追逐强度和局内节奏关联。比赛提供的曲目须按比赛规则使用；AI 生成素材需在投稿说明中披露。
