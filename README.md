# PixelPlaneWar · 像素飞机大战

> 2D 纵向卷轴飞行射击游戏
> Vertical-scrolling 2D shoot 'em up

---

## 项目信息

| 项 | 值 |
|---|---|
| 引擎 | Unity 2023.1.1f1c1 |
| 类型 | 2D 飞行射击（弹幕） |
| 语言 | C# |
| 平台 | Android / Windows |
| 版本 | 1.0 |

---

## 玩法

操控战机在星空中飞行，躲避敌人弹幕并击落敌机，尽可能拿到高分。

### 核心机制

| 系统 | 说明 |
|---|---|
| **玩家控制** | 移动速度 15，可在屏幕内自由飞行 |
| **自动/手动射击** | 射击间隔 0.3 秒，可连续发射 |
| **敌人类型** | 飞机敌 / 坦克敌，各有不同行为 |
| **敌人弹幕** | 敌人会向玩家发射子弹 |
| **血量系统** | 玩家有独立生命值 |
| **道具掉落** | 击落敌人有概率掉落道具 |
| **得分系统** | 击落敌人得分，不同类型分数不同 |

### 三种道具

| 道具 | 效果 | 基础掉落率 |
|---|---|---|
| ❤️ 生命道具 | 恢复生命值 | 20% |
| 🛡️ 护盾道具 | 提供护盾保护 | 10% |
| 💣 炸弹道具 | 清屏/范围伤害 | 5% |

---

## 项目结构

```
PixelPlaneWar/
├── Assets/
│   ├── Art/            美术资源（79 MB）
│   │   ├── Font/       中文字体（MSYH 系列 + TMP 图集）
│   │   ├── Sprites/    精灵图
│   │   └── ...
│   ├── Audio/          音频
│   ├── Editor/         编辑器脚本
│   ├── Materials/      材质
│   ├── Prefabs/        预制体
│   ├── Scenes/
│   │   ├── Game.unity      ★ 主场景
│   │   └── SampleScene.unity
│   ├── Scripts/        游戏逻辑（18 个脚本）
│   │   ├── Combat/
│   │   │   ├── BulletMovement.cs    子弹移动
│   │   │   ├── EnemyWeapon.cs       敌人武器
│   │   │   └── ExplosionEffect.cs   爆炸特效
│   │   ├── Enemy/
│   │   │   ├── EnemyBase.cs         敌人基类（血量/得分/掉落）
│   │   │   ├── AircraftEnemy/       飞机敌
│   │   │   ├── TankEnemy/           坦克敌
│   │   │   └── EnemyBullet/         敌人子弹
│   │   ├── Manager/
│   │   │   ├── GameManager.cs       游戏状态（开始/暂停/结束）
│   │   │   ├── ScoreManager.cs      得分管理
│   │   │   ├── EnemySpawner.cs      敌人生成
│   │   │   └── StarfieldBackground.cs 星空背景
│   │   ├── Player/
│   │   │   ├── PlayerController.cs  玩家移动
│   │   │   ├── PlayerWeapon.cs      玩家射击
│   │   │   └── PlayerHealth.cs      玩家生命
│   │   ├── Prop/
│   │   │   ├── BombProp.cs          炸弹道具
│   │   │   ├── HealthProp.cs        生命道具
│   │   │   └── ShieldProp.cs        护盾道具
│   │   └── EscQuit.cs               按 Esc 退出
│   └── TextMesh Pro/   TMP 资源
├── Packages/           Unity 包清单
├── ProjectSettings/    项目设置
├── .gitignore
├── .gitattributes
└── README.md
```

---

## 运行项目

### 前置要求

- **Unity 2023.1.1f1c1**（或其他 2023.1.x）
- Unity Hub

### 打开

1. 克隆仓库
   ```bash
   git clone <仓库地址>
   ```

2. Unity Hub → `Add` → 选择 `PixelPlaneWar` 文件夹

3. 用 **2023.1.1f1c1** 打开（首次会重建 `Library`，约 2~5 分钟）

4. 打开 `Assets/Scenes/Game.unity`，点击 **Play**

---

## 构建

### Android

1. Unity → `File` → `Build Settings`
2. Platform 选 **Android**
3. 确认 `Assets/Scenes/Game.unity` 在场景列表且已勾选
4. `Player Settings` → 设置 Package Name
5. 点击 `Build`

> ⚠️ 如需发布到应用商店，需要配置签名 Keystore。**不要把 keystore 上传到公开仓库。**

### Windows

Platform 改为 `Windows`，架构选 `x86_64`，点击 `Build`。

---

## 主要参数（可在 Inspector 调整）

| 脚本 | 参数 | 默认值 |
|---|---|---|
| `PlayerController` | `moveSpeed` | 15 |
| `PlayerWeapon` | `fireInterval` | 0.3 秒 |
| `EnemyBase` | `maxHealth` | 2 |
| `EnemyBase` | `scoreValue` | 100 |
| `EnemyBase` | `dropChance`（生命） | 0.2 |
| `EnemyBase` | `shieldDropChance`（护盾） | 0.1 |
| `EnemyBase` | `bombDropChance`（炸弹） | 0.05 |

---

## 字体说明

项目使用 **微软雅黑（MSYH / MSYHBD / MSYHL）** 作为中文字体。

> ⚠️ 微软雅黑是微软的**商业字体**，随 Windows 系统分发，但**不可再分发**。
> 如需公开发布游戏，建议替换为开源中文字体，例如：
> - [思源黑体 Source Han Sans](https://github.com/adobe-fonts/source-han-sans)（SIL OFL）
> - [阿里巴巴普惠体](https://www.iconfont.cn/fonts)（免费商用）

---

## 许可

项目代码版权归作者所有。

第三方资源：
- TextMesh Pro —— Unity 官方包
- 微软雅黑字体 —— 版权归微软，见上方说明

---

## 截图

（暂无）