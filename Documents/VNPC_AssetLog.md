# VNPC - Asset Evaluation Log

**Purpose:** Track every asset, package, and technique evaluated for the VNPC toolkit project. This project serves as a shared base for multiple games (2 visual novels, 2 point-and-click adventures).

**Last Updated:** May 11, 2026 (Session 12 -- Project Relevance tables updated post P&C split; AC/Ink entries marked as moved-to-standalone-project)

---

## How to Use This Document

Every asset tested gets an entry here. Entries are never deleted -- failed evaluations are just as valuable as successful ones.

### Entry Lifecycle

1. **Add entry** when you start evaluating an asset (status: Testing)
2. **Update verdict** when evaluation is complete
3. **Add notes** about quirks, performance, integration cost
4. **Tag applicability** (VN, P&C, or Both)

### Verdict Definitions

| Verdict | Meaning |
|---------|---------|
| **Approved** | Works well, recommended for use |
| **Approved - Default** | Approved and included in default project template |
| **Conditional** | Works but has caveats (performance, compatibility, workflow) |
| **Rejected** | Does not meet requirements or has blocking issues |
| **Testing** | Evaluation in progress |
| **Deferred** | Not tested yet, queued for future evaluation |

---

## Summary Table

| # | Asset | Source | Category | Verdict | Applies To | Date |
|---|-------|--------|----------|---------|------------|------|
| 001 | Adventure Creator | Asset Store | Framework (P&C) | Approved - Default | P&C | 2026-02-21 |
| 002 | Dialogue System for Unity | Asset Store | Dialogue / Quests | Approved - Default | Both | 2026-02-21 |
| 003 | Ink Integration for Unity | Asset Store / GitHub | Narrative Scripting | Approved - Default | Both | 2026-02-21 |
| 004 | Naninovel | Asset Store / Elringus | Framework (VN) | Approved - Default | VN | 2026-02-21 |
| 005 | Text Animator for Unity | Asset Store | UI / Text Effects | Approved - Default | Both | 2026-02-21 |
| 006 | DOTween Pro | Asset Store | Animation / Tweening | Approved - Default | Both | 2026-02-21 |
| 007 | Odin Inspector and Serializer | Asset Store | Tools / Editor | Approved - Default | Both | 2026-02-21 |
| 008 | R3 (Cysharp) | NuGet | Architecture (Reactive) | Installed | Both | 2026-02-21 |
| 009 | PlayerPrefsEx (IvanMurzak) | OpenUPM | Data | Installed | Both | 2026-02-21 |

---

## Detailed Evaluations

---

#### ENTRY-001: Adventure Creator 1.85.5 (Icebox Studios / Chris Burton)

**Date:** 2026-02-21 (Session 1), upgraded 2026-03-09 (Session 4)
**Source:** Asset Store
**Category:** Framework (2D/2.5D/3D Adventure Game / Point-and-Click Engine)
**Verdict:** Approved - Default
**Applies To:** P&C games
**Namespace:** `AC`
**Publisher:** Chris Burton (Icebox Studios)

##### Overview

Adventure Creator is the Unity standard for point-and-click adventure game development. Complete no-code/low-code framework for 2D, 2.5D, and 3D adventure games: visual ActionList scripting, inventory with crafting/combinations, dialogue trees, cutscenes, camera systems, save/load, translations, QTEs, and a full navigation system. Supports all three perspectives with dedicated templates and demo scenes. Actively maintained for 10+ years. Unity 6 compatible (6000.0.45f1 tested). Built-in, URP, HDRP compatible.

**Notable Games:** Harold Halibut, Sally Face, Kathy Rain, Colossal Cave (Roberta Williams), Phoenix Springs, Little Misfortune, Yes Your Grace, Hollowbody.

##### Asset Structure

```
Assets/AdventureCreator/
  Scripts/          -- 675 scripts, 1 asmdef (AC)
  Editor/           -- editor windows and tools
  Prefabs/          -- AC system prefabs
  Resources/        -- runtime resources
  UI/               -- default UI prefabs
  Graphics/         -- icons, cursors (~37 MB)
  Default/          -- default ActionList assets
  Demo/             -- 3D demo game (~123 MB)
  2D Demo/          -- 2D demo game (~96 MB)
  Manual.pdf        -- comprehensive manual (~23 MB)
  changelog.txt     -- version history
```

**Total scripts:** 675 (.cs files)
**Estimated LOC:** ~56,000
**Asmdefs:** 1 (`AC`)
**Total asset size:** ~551 MB (including demos)

##### Manager Architecture

AC is configured through 8 global Manager assets, all edited in the Game Editor window (`Adventure Creator > Editors > Game Editor`):

| Manager | Controls |
|---------|---------|
| `SceneManager` | NavMesh, cameras, scene initialization |
| `SettingsManager` | Movement method, input method, interaction style, camera perspective |
| `ActionsManager` | Which Action types are available, custom action registration |
| `VariablesManager` | Global/local variables, scene attributes, timers |
| `InventoryManager` | Items, crafting, documents, objectives, properties |
| `SpeechManager` | Dialogue lines, translations, lip sync, script sheets |
| `CursorManager` | Cursor icons per interaction type |
| `MenuManager` | All in-game menus (AC menus or Unity UI) |

##### ActionList Visual Scripting (126 Action nodes)

ActionLists are AC's no-code scripting system -- sequences of Actions that can be triggered by hotspots, conversations, cutscenes, or triggers. 126 built-in Action types covering:

**Character:** `ActionCharAnim`, `ActionCharFace`, `ActionCharFaceDirection`, `ActionCharFollow`, `ActionCharMove`, `ActionCharPathFind`, `ActionCharPortrait`, `ActionCharRender`

**Camera:** `ActionCamera`, `ActionCameraCheck`, `ActionCameraCrossfade`, `ActionCameraShake`, `ActionCameraSplit`, `ActionCameraTP`

**Dialogue / Speech:** `ActionSpeech`, `ActionSpeechStop`, `ActionSpeechWait`, `ActionConversation`, `ActionDialogOption`

**Inventory:** `ActionInventoryCheck`, `ActionInventorySet`, `ActionInventorySelect`, `ActionInventoryInteraction`, `ActionInvProperty`, `ActionInventoryPrefab`

**Variables:** `ActionVarCheck`, `ActionVarCopy`, `ActionVarSet`, `ActionVarPreset`, `ActionVarSequence`

**Scene / Flow:** `ActionScene`, `ActionSceneAdd`, `ActionSceneCheck`, `ActionRunActionList`, `ActionStopActionList`, `ActionPause`, `ActionParallel`, `ActionEnd`

**Object / Transform:** `ActionTeleport`, `ActionTransform`, `ActionParent`, `ActionVisible`, `ActionChangeMaterial`, `ActionInstantiate`, `ActionSendMessage`

**Save / Options:** `ActionSaveHandle`, `ActionSaveCheck`, `ActionManageSaves`, `ActionManageProfiles`, `ActionOptionSet`

**Menu:** `ActionMenuCheck`, `ActionMenuState`, `ActionMenuItem`, `ActionMenuJournal`, `ActionMenuSelect`

**Audio / Media:** `ActionSound`, `ActionSoundShot`, `ActionMusic`, `ActionAmbience`, `ActionMixerSnapshot`, `ActionVolume`, `ActionMovie`

**Animation / FX:** `ActionAnim`, `ActionBlendShape`, `ActionSpriteFade`, `ActionHighlight`, `ActionFade`, `ActionTintMap`

**Timeline:** `ActionTimeline`, `ActionTrackCheck`, `ActionTrackRegion`, `ActionTrackSet`

**Input / QTE:** `ActionInputActive`, `ActionInputCheck`, `ActionInputSimulate`, `ActionQTE`

##### Character System

Core architecture built on `Char.cs` (4,864 lines) as base class:

- **Player.cs** (1,552 lines) -- player-specific behavior
- **NPC.cs** (864 lines) -- NPC-specific behavior
- 6 animation engine types: Mecanim, SpritesUnity, SpritesUnityComplex, Sprites2DToolkit, Legacy, Custom
- Expression system with blendshapes
- Lip-sync (automatic, SALSA integration, texture-based)
- Movement, turning, head tracking, IK
- Timeline integration: CharacterAnimation2D/3D tracks, HeadTurnTrack

##### Camera System

7 built-in GameCamera types: `GameCamera` (standard follow), `GameCamera2D`, `GameCamera2DDrag`, `GameCamera25D` (2.5D background with sprite depth), `GameCameraAnimated`, `GameCameraThirdPerson`, `FirstPersonCamera`. Full Cinemachine integration (exclusive or mixed mode). Timeline camera tracks included. 37 camera-related scripts total.

##### Navigation

5 pathfinding backends: Unity NavMesh, Mesh Collider, Polygon Collider, A* 2D (built-in), Custom. `NavigationEngine` base class for custom implementations. 30 navigation-related scripts including SortingMap, Markers, FootstepSounds.

##### Save System (54 scripts)

Full scene state serialization with 20+ `Remember*` components for every AC object type (RememberTransform, RememberAnimator, RememberNPC, RememberHotspot, RememberContainer, RememberConversation, RememberMaterial, RememberSound, RememberTimeline, RememberVideoPlayer, RememberVisibility, etc.). Three file format handlers: Binary, JSON, XML. Two save backends: SystemFile, PlayerPrefs. Save profiles, autosave, loading screens. Custom save data via `ISave` interface.

##### Inventory System (24 scripts)

`RuntimeInventory`, `InvCollection`, `InvItem`, `InvInstance` core classes. Crafting via `Recipe`, `Ingredient`, `IngredientCollection`. Item properties via `InvVar`. Containers via `ContainerItem`. Scene-placed items via `SceneItem`. Import/export wizards for bulk item data. `MenuInventoryBox` (92KB) handles all inventory UI display and interaction.

##### Speech & Dialogue

Built-in dialogue authoring with translation support (CSV export/import via script sheets). `Speech.cs` manages active dialogue with audio sync, skip logic, text scrolling. `Conversation.cs` for multi-option dialogue trees. Lip sync (automatic, SALSA, texture-based). Facial expressions. External tool integration via Dialogue System (ENTRY-002).

##### Menu System (36+ scripts)

19 menu element types: `MenuButton`, `MenuLabel`, `MenuInput`, `MenuToggle`, `MenuSlider`, `MenuGraphic`, `MenuInteraction`, `MenuDrag`, `MenuInventoryBox`, `MenuCrafting`, `MenuCycle`, `MenuDialogList`, `MenuJournal`, `MenuSavesList`, `MenuProfilesList`, `MenuTimer`, `CursorIcon`. Core `Menu.cs` (110KB) and `MenuElement.cs` (49KB) handle all menu logic. Supports both AC-native menus and Unity UI.

##### Templates

`SamplePlayer2D`, `SamplePlayer3D`, `SamplePlayerFP` -- player characters per perspective
`SampleScene2D`, `SampleScene3D` -- scene starters with comments
`NineVerbs` -- classic LucasArts 9-verb interface
`TitleScreen` -- main menu with New/Continue
`GraphicOptions` -- resolution/quality settings menu
`MobileJoystick` -- on-screen touch controls
`TMPro` -- converts all menus to TextMesh Pro
`AnimatedCursor` -- Unity UI animated cursor
`CutsceneBorders` -- letterbox effect for cutscenes

##### AI-Friendliness

- Full C# API via `KickStarter.*` static class -- move characters, play speech, change cameras, modify inventory, set variables all from code
- `EventManager` with 100+ event hooks for custom logic
- ActionLists can be created dynamically via `ScriptableObject.CreateInstance<ActionType>()`, configured, and run from C#
- Direct API calls can bypass ActionLists entirely for simpler scripting
- Custom Actions extensible via C# (inherit from `Action`)
- Parameterized ActionList Assets allow template-based authoring

##### Integrations

**Built-in:** Addressables, Unity Localization, PlayMaker (variable linking + FSM event calling), SALSA lip sync, TextMesh Pro, Timeline (custom tracks for cameras, characters, speech)

**Official downloads (AC website):** Cinemachine, Input System, AI Tree, articy:draft, Kinematic Character Controller, Ultimate Character Controller

**Installed in VNPC:** Dialogue System for Unity (official deep integration -- 15+ custom AC Actions, variable sync, sequencer commands), Ink (community integration via AC-Ink-Integration GitHub package), Cinemachine 3.1.5, Input System 1.18.0, Timeline 1.8.10, DOTween Pro, Text Animator (community wiki integration)

**Integration path:** Naninovel -- for hybrid VN/P&C segments (switch between "novel mode" and "adventure mode")

##### Verdict Rationale

Approved - Default. Adventure Creator is the uncontested Unity standard for point-and-click adventure development with over a decade of active maintenance. The ActionList visual scripting, 8-manager system, and full-perspective support (2D/2.5D/3D) make it a complete foundation. 675 scripts, ~56K LOC, single clean `AC` namespace.

For the VNPC project, AC is the engine for the two planned P&C games (titles TBD). It handles everything the P&C games need: hotspots, navigation, inventory, cutscenes, cameras, save/load. The Dialogue System integration provides richer branching logic than AC's built-in conversation nodes. Ink integration enables the narrative scripting pipeline. Not needed for the VN games (Naninovel handles those).

##### Project Relevance

| Game | Relevance | Notes |
|------|-----------|-------|
| Genie in a Test Tube (VN) | NONE | VN -- Naninovel handles this |
| Encapsulated Fear (VN) | NONE | VN -- Naninovel handles this |
| GRIMMORPG (P&C) | Moved out | Originally planned to use AC in VNPC. GRIMMORPG split to standalone project at `E:\Unity\GRIMMORPG` in April 2026 and dropped AC for a modular stack (Dialogue System + Ink + Animancer Pro + Easy Save 3 + Inventory Framework 2). |
| P&C Game 2 (title TBD) | Moved out | Will live in its own project once source is written. Stack TBD. |

Adventure Creator remains installed in VNPC for historical/cross-eval reference but is not used by any VNPC game.

**Docs:** [Manual PDF](https://adventurecreator.org/files/Manual.pdf) | [Scripting Guide](https://adventurecreator.org/scripting-guide/) | [Tutorials](https://adventurecreator.org/tutorials) | [Forum](https://adventurecreator.org/forum/)

---

#### ENTRY-002: Dialogue System for Unity

| Field | Value |
|-------|-------|
| **Asset** | Dialogue System for Unity |
| **Source** | Asset Store (Pixel Crushers) |
| **Version** | 2.2.65.1 |
| **Category** | Dialogue / Quests / Narrative |
| **Date Started** | 2026-02-21 |
| **Date Completed** | 2026-02-21 |
| **Verdict** | Approved - Default |
| **Applies To** | Both (VN and P&C) |

**What It Does:**
All-in-one dialogue middleware: branching conversations (visual node editor), quest system with sub-tasks, bark system (one-liner NPC dialogue), cutscene sequencer, save/load, NPC relationship tracking, localization with CSV export, and professional UI templates. Embeds a Lua interpreter for conditions and scripts. MVC architecture. 840+ reviews, 5/5 stars -- highest-rated dialogue asset on the store. Used in Disco Elysium.

**Notable Games:** Disco Elysium (GOTY), Suzerain, Lake, Citizen Sleeper, 1000xRESIST, Peglin, Jenny LeClue.

**AI-Friendliness:**
- **Excellent.** Complete databases can be built programmatically in C# via `Template` class (create actors, conversations, dialogue entries, quests, variables, link nodes -- zero GUI needed)
- `DialogueManager` static class for all runtime operations: `StartConversation()`, `Bark()`, `PlaySequence()`, `ShowAlert()`, `StopConversation()`
- `DialogueLua` for variable get/set: `DialogueLua.GetVariable()`, `SetVariable()`
- `QuestLog` for quest management: `SetQuestState()`, `GetQuestState()`
- JSON/CSV export/import -- AI can generate dialogue data files
- Ink/Yarn scripts import natively -- AI writes .ink files, Dialogue System consumes them
- Custom Lua functions registerable via `Lua.RegisterFunction()`
- C# events for all conversation lifecycle hooks

**What Requires Manual Editor Work:**
- Dialogue Manager prefab placement (one-time per scene/project)
- UI prefab setup (templates included)
- Initial DialogueSystemTrigger components on GameObjects (optional -- can bypass entirely with `DialogueManager.StartConversation()` from code)

**What I (Claude) Can Do:**
- Generate complete dialogue databases in C# (programmatic creation)
- Generate JSON/CSV files for import
- Write .ink scripts that import natively
- Write Lua conditions and scripts for dialogue nodes
- Manage conversations, quests, barks, and variables at runtime via C# API
- Register custom Lua functions
- Wire up MonoBehaviours that start/stop conversations

**Integration Points (installed):**
- Adventure Creator -- official deep bridge (15+ custom AC Actions, AC variable/inventory sync with Lua)
- Ink Integration -- official (runs Ink as live runtime, bidirectional variable sharing)
- Text Animator v3.3+ -- official integration (TextAnimatorSubtitlePanel, sequencer commands)
- Naninovel -- no official integration (competing approaches, but can coexist for different game types in toolkit)
- DOTween Pro (installed) -- sequencer support
- Cinemachine (installed) -- sequencer camera commands
- FMOD / Wwise -- built-in audio middleware support

**Docs:** [Manual 2.x](https://www.pixelcrushers.com/dialogue_system/manual2x/html/) | [Scripting](https://www.pixelcrushers.com/dialogue_system/manual2x/html/scripting.html) | [Forum](https://www.pixelcrushers.com/phpbb/viewforum.php?f=3)

---

#### ENTRY-003: Ink Integration for Unity

| Field | Value |
|-------|-------|
| **Asset** | Ink Integration for Unity (+ Ink language by Inkle) |
| **Source** | Asset Store / GitHub (MIT license) |
| **Version** | 1.1.8 (Unity integration); Ink 1.2.0 (compiler/runtime) |
| **Category** | Narrative Scripting |
| **Date Started** | 2026-02-21 |
| **Date Completed** | 2026-02-21 |
| **Verdict** | Approved - Default |
| **Applies To** | Both (VN and P&C) |

**What It Does:**
Ink is an open-source narrative scripting language by Inkle Studios. `.ink` files are plain text with minimal markup for branching stories: knots/stitches (chapters/scenes), choices (`*`/`+`), diverts (`->`), variables (`VAR`), conditional text (`{}`), sequences/cycles/shuffles, functions, tunnels, threads, lists (multi-valued state tracking), tags (`#`), and external function hooks. The Unity integration provides C# runtime API, auto-compilation (.ink to .json), and an in-editor Ink Player debugging window.

**Ink is pure middleware** -- it handles narrative logic only. No audio, no visuals, no UI, no animation. The game engine consumes text/choices/tags and handles all presentation. This is by design and makes it engine-agnostic.

**Notable Games:** 80 Days (TIME GOTY 2014), Sable, Heaven's Vault, Vampire: The Masquerade -- Bloodlines 2, Banner Saga 3, Sea of Thieves, Falcon Age, Where the Water Tastes Like Wine, Goodbye Volcano High.

**AI-Friendliness:**
- **Best of all five assets.** Pure plain-text .ink files -- the most AI-writable format possible.
- Well-documented syntax with only 4 core concepts (text, choices, diverts, variables)
- Compiled by `inklecate` with clear error messages for validation
- AI generates .ink files -> auto-compiles in Unity -> runs via Dialogue System or direct C# runtime
- External functions bridge to game engine (`EXTERNAL playSound(name)`)
- Tags bridge metadata to presentation layer (`# speaker:John # mood:angry`)
- INCLUDE system for multi-file story organization

**What Requires Manual Editor Work:**
- Nothing for authoring -- .ink files are pure text
- One-time: configure Ink Integration component on Dialogue Manager (if using with Dialogue System)

**What I (Claude) Can Do:**
- Write complete .ink narrative scripts with full branching, variables, conditions, functions
- Generate multi-file story structures with INCLUDE
- Define external function interfaces for game engine hooks
- Write C# runtime integration code
- Generate tag conventions for speaker assignment, audio cues, animation triggers

**Ink Syntax Quick Reference (for AI authoring):**
```
=== knot_name ===           // Major section
= stitch_name               // Subsection
-> knot_name                 // Divert (go to)
* [Choice text] Result       // Single-use choice
+ [Choice text] Result       // Sticky choice (repeatable)
- Gather point               // Where branches rejoin
VAR name = "value"           // Global variable
~ name = "new"               // Modify variable
{condition: true | false}    // Conditional text
{&cycle|options|here}        // Cycling text
{~random|options|here}       // Shuffle text
EXTERNAL funcName(args)      // Game engine hook
# tag_name                   // Metadata tag
-> END                       // End story
```

**Integration Points (installed):**
- Dialogue System for Unity -- official integration (Ink runs as live runtime, bidirectional variable sharing via Lua functions)
- Adventure Creator -- community integration (AC-Ink-Integration GitHub package)
- Text Animator -- works naturally (embed TA tags in Ink text output)

**Docs:** [Writing with Ink](https://github.com/inkle/ink/blob/master/Documentation/WritingWithInk.md) | [Runtime API](https://github.com/inkle/ink/blob/master/Documentation/RunningYourInk.md) | [Web Tutorial](https://www.inklestudios.com/ink/web-tutorial/)

**Cost:** FREE (MIT license)

---

#### ENTRY-004: Naninovel 1.21 (Elringus)

**Date:** 2026-02-21 (Session 1), upgraded 2026-03-09 (Session 4)
**Source:** Asset Store / Elringus
**Category:** Framework (Visual Novel / Storytelling Engine)
**Verdict:** Approved - Default
**Applies To:** VN games
**Namespace:** `Naninovel`
**Publisher:** Elringus

##### Overview

Comprehensive visual novel / storytelling engine for Unity. Provides: text printers (ADV/NVL styles with typewriter reveal), character actor system (sprites, diced sprites, Live2D, Spine, 3D meshes -- with appearances, positions, lip sync), backgrounds with 30+ transition effects, branching choices, complete save/load with multiple slots, state rollback, skip & auto-advance, voicing system with auto-voicing, BGM/SFX/ambient audio, localization pipeline, special effects (rain, snow, blur, shake, bokeh, glitch, sun), unlockable CG gallery/tips, custom variables and expressions, full UI system (title screen, settings, backlog, 27 UI subsystems), and input processing. Service-oriented architecture. Developed for 10+ years. 5/5 stars, 74 reviews. Unity 6 compatible.

##### Asset Structure

```
Packages/com.elringus.naninovel/
  Runtime/          -- 731 scripts (core engine)
    Actor/          -- character, background, printer, choice handler systems
    Audio/          -- BGM, SFX, voice playback
    Camera/         -- camera manipulation
    Commands/       -- 95 executable script commands
    Common/         -- utilities, async, collections, events, tweens (58 files)
    Configuration/  -- 23 configuration classes
    Console/        -- debug console
    CustomVariable/ -- state variables
    Engine/         -- core engine, service system, initialization
    Expression/     -- expression evaluation
    FX/             -- visual effects, transitions
    Input/          -- input handling
    Localization/   -- multi-language support (19 classes)
    ManagedText/    -- managed text strings
    Movie/          -- video playback
    Resource/       -- resource loading, providers
    Script/         -- script parsing, compilation, playback
    Spawn/          -- procedural spawning
    State/          -- save/load, rollback
    Timeline/       -- Timeline integration
    Transition/     -- scene transitions
    UI/             -- 27 UI subsystems
    Unlockable/     -- CG gallery, tips
  Editor/           -- 159 scripts (editor tools)
  E2E/              -- 12 scripts (end-to-end testing)
  Prefabs/          -- UI, actor, effect prefabs
  Resources/        -- default resources
  Samples~/         -- Visual Novel sample
```

**Total scripts:** 902 (.cs files: 731 Runtime, 159 Editor, 12 E2E)
**Estimated LOC:** ~25,300
**Asmdefs:** 3 (`Elringus.Naninovel.Runtime`, `Elringus.Naninovel.Editor`, `Elringus.Naninovel.E2E`)

##### Command System (95 commands)

All commands extend the `Command` base class and are auto-discovered by the engine. Commands map directly to `@command` syntax in .nani scripts.

**Actors (13):** `ModifyCharacter`, `ModifyBackground`, `ModifyActor`, `ModifyOrthoActor`, `ShowActors`, `HideActors`, `HideAllActors`, `HideAllCharacters`, `ArrangeCharacters`, `AnimateActor`, `SlideActor`, `RemoveActors`, `LipSync`

**Audio (8):** `PlayBgm`, `StopBgm`, `PlaySfx`, `StopSfx`, `PlaySfxFast`, `PlayVoice`, `StopVoice`, `AudioCommand` (base)

**Text / Printers (10):** `PrintText`, `AppendText`, `ResetText`, `FormatText`, `ShowPrinter`, `HidePrinter`, `ModifyTextPrinter`, `ClearBacklog`, `PrinterCommand` (base), `ParametrizeGeneric`

**Branching / Logic (13):** `AddChoice`, `RequireChoice`, `ClearChoiceHandler`, `ModifyChoiceHandler`, `BeginIf`, `Else`, `EndIf`, `Unless`, `While`, `SelectRandom`, `SetCustomVariable`, `InputCustomVariable`, `ResetState`

**Playback Control (13):** `Goto`, `Gosub`, `Return`, `Stop`, `Skip`, `Wait`, `Await`, `AwaitInput`, `DisableAwaitInput`, `ExecuteAsync`, `Sync`, `Group`, `EnterDialogue`/`ExitDialogue`

**Visuals / Effects (16+):** `ModifyCamera`, `CameraLook`, `Spawn`, `DestroySpawned`, `DestroyAllSpawned`, `SpawnBlur`, `SpawnBokeh`, `SpawnGlitch`, `SpawnRain`, `SpawnShake`, `SpawnSnow`, `SpawnSun`, `SpawnEffect`, `TransitionScene`, `PlayMovie`, `ControlTimeline`

**UI / System (12):** `ShowUI`, `HideUI`, `ShowToastUI`, `Lock`, `Unlock`, `AutoSave`, `LoadScene`, `UnloadScene`, `OpenURL`, `ProcessInput`, `PurgeRollback`, `ExitToTitle`

##### Actor System (11 implementation types)

| Actor Type | Description |
|------------|-------------|
| `SpriteActor` | Standard sprite-based (Character, Background) |
| `DicedSpriteActor` | Sprite dicing for memory optimization |
| `LayeredActor` | Composite layered characters (body + face + clothes) |
| `GenericActor` | Custom prefab-based actors |
| `VideoActor` | Video as actor appearance |
| `Live2DActor` | Live2D model integration |
| `SpineActor` | Spine skeleton animation |
| `SceneBackground` | Unity scene as background |
| `NarratorCharacter` | Speaker with no visual representation |
| `PlaceholderActor` | Colored shapes with ID labels (dev/testing) |
| `TransientActor` | Runtime-created actors |

Each type has Character, Background, TextPrinter, and ChoiceHandler variants where applicable. Managed by `CharacterManager`, `BackgroundManager`, `TextPrinterManager`, `ChoiceHandlerManager`.

##### Configuration System (23 classes)

All extend `Configuration` base, edited via `Naninovel > Configuration` menu:

| Configuration | Controls |
|---------------|---------|
| `EngineConfiguration` | Engine behavior, initialization |
| `CameraConfiguration` | Camera settings, rendering |
| `InputConfiguration` | Input mapping, event system |
| `ScriptsConfiguration` | Script loading, community scripts |
| `ScriptPlayerConfiguration` | Playback speed, skip mode |
| `CharactersConfiguration` | Character defaults, auto-arrange |
| `BackgroundsConfiguration` | Background defaults |
| `TextPrintersConfiguration` | Printer defaults, reveal speed |
| `ChoiceHandlersConfiguration` | Choice UI defaults |
| `AudioConfiguration` | BGM/SFX/voice settings |
| `StateConfiguration` | Save/load behavior, slots |
| `LocalizationConfiguration` | Language settings |
| `ResourceProviderConfiguration` | Resource provider priorities |
| `UIConfiguration` | UI system settings |
| `SpawnConfiguration` | Spawn object registry |
| `UnlockablesConfiguration` | CG gallery, tips |
| `CustomVariablesConfiguration` | Variable defaults |
| `ManagedTextConfiguration` | Managed text strings |
| `MoviesConfiguration` | Video playback |
| + 4 base/utility configs | |

##### UI System (27 subsystems)

Pre-built UI panels covering the complete VN experience:

**Core gameplay:** Backlog (message history), ClickThrough (continue indicator), ContinueInput, ControlPanel (save/load/settings/skip/autoplay buttons), TextPrinter (dialogue display + author name), ChoiceHandler (branching choices)

**Menus:** Title (title screen), Pause, GameSettings (resolution, volume, text speed), SaveLoad (slot management with screenshots), Confirmation (yes/no dialogs)

**Extras:** CGGallery (unlockable CG viewer), Tips (hints/achievements gallery), ScriptNavigator (debug script jumping), Toast (notifications), Movie (video player), Loading (loading screen), Rollback (state undo), ExternalScripts, VariableInput, Debug

All UI implements `IManagedUI` interface. Custom UIs register with `IUIManager`.

##### Script System

**Parsing:** `ScriptCompiler` → `ScriptLineCompiler` → specialized compilers (`CommandLineCompiler`, `GenericLineCompiler`, `LabelLineCompiler`, `CommentLineCompiler`). 30+ parameter types (`StringParameter`, `IntegerParameter`, `DecimalParameter`, `BooleanParameter`, `NamedParameter` variants, `LocalizableTextParameter`, etc.).

**Execution:** `ScriptPlayer` drives playback. `PlaybackOptions` configures behavior. `ExecutionContext` tracks state. `ScriptTrack` enables parallel execution.

**Script model:** `Script` → `ScriptLine` (base) → `CommandLine`, `GenericLine` (dialogue/narration), `LabelLine`, `CommentLine`, `EmptyLine`.

##### Save / Load & State Management

- `StateManager` -- main state service with quick/auto/manual save types
- `GameStateMap` -- per-playthrough state
- `GlobalStateMap` -- global persistent state (unlockables, settings)
- `SettingsStateMap` -- game settings
- `StateRollbackStack` -- undo/rollback history (configurable depth)
- Three save slot backends: `IOSaveSlotManager` (file system), `PlayerPrefsSaveSlotManager`, `TransientSaveSlotManager` (in-memory)
- `UniversalSerializationHandlers` -- standard serialization

##### Resource System (6 provider types)

| Provider | Description |
|----------|-------------|
| `ProjectResourceProvider` | Unity Resources folder |
| `LocalResourceProvider` | Local file system |
| `AddressableResourceProvider` | Unity Addressables (optional) |
| `VirtualResourceProvider` | Custom/virtual resources |
| `ResourceProvider` | Base provider |
| + converters | JPG/PNG→Texture, WAV→AudioClip, TXT→TextAsset, .nani→Script |

`ResourceProviderManager` coordinates provider priority. `LocalizableResourceLoader` handles locale-aware loading.

##### Localization (19 classes)

`LocalizationManager` manages language switching. Scripts and UI localized via `LocalizableText`. CSV export/import for translation. `ScriptLocalizationParser` for .nani localization overlays. Community localization support. Detected languages at runtime.

##### AI-Friendliness

- **Excellent.** `.nani` scripts are plain-text files with simple syntax (4 line types: commands `@`, text, labels `#`, comments `;`)
- AI can write complete scenario scripts as text files -- no GUI needed for narrative authoring
- Custom commands via C# (derive from `Command`, auto-discovered by engine)
- Engine services accessible via `Engine.GetService<T>()` for full C# control
- VS Code extension available for syntax highlighting/autocomplete
- Metadata JSON generated for context-aware script generation

**NaniScript Quick Reference:**
```nani
; Comment
# Label
@char Sora.Happy look:left pos:45,10
@back River
@bgm CloudNine fade:10
@camera offset:-3,1.5 zoom:0.5 time:5
Sora: Welcome to our story.
@choice "Go left" goto:#Left
@choice "Go right" goto:#Right
@set score+=10
@if score>6
    You passed!
@else
    Try again!
@endif
@goto Script001#AfterStorm
```

##### Integrations

**Official extensions (not installed):** Live2D, Spine -- character animation middleware

**Installed in VNPC:** Text Animator (custom integration via `TATextPrinterPanel` -- VNPC Phase 1), DOTween Pro, Cinemachine, Input System, Timeline

**Integration path:** Adventure Creator -- for hybrid VN/P&C segments (switch between "novel mode" and "adventure mode")

**No official integration:** Dialogue System (competing approaches; use DS for P&C games, Naninovel for VN games)

##### VNPC Custom Integration: Text Animator

**Status:** COMPLETE (Phase 1). Custom `TATextPrinterPanel.cs` extends `UITextPrinterPanel`, bypasses Naninovel's `RevealableText` entirely. Text Animator controls all TMPro rendering (reveal, wave, shake, bounce). Naninovel controls timing. Tags (`<wave>`, `<shake>`, `<bounce>`, `<wiggle>`) survive Naninovel's script parser intact. See `VNPC_CodeReference.md` for API details.

##### Verdict Rationale

Approved - Default. Naninovel is the most complete VN engine available for Unity. 902 scripts, ~25K LOC across 3 assemblies, clean `Naninovel` namespace. Service-oriented architecture with 23 configuration classes provides deep customization without code changes. The .nani script format is ideal for AI-assisted authoring -- plain text, simple syntax, full narrative control.

For the VNPC project, Naninovel is the engine for both VN games (Genie in a Test Tube, Encapsulated Fear). It handles everything the VN games need: text display, character management, backgrounds, choices, save/load, rollback, audio, UI. The Text Animator integration (Phase 1) adds per-character text effects that Naninovel lacks natively. The placeholder actor system enables full greybox prototyping before any art is created.

##### Project Relevance

| Game | Relevance | Notes |
|------|-----------|-------|
| Genie in a Test Tube (VN) | HIGH | Primary engine. Naninovel + Text Animator stack. Phase 4 (TA polish) complete; Phase 5 (Audio) next. |
| Encapsulated Fear (VN) | HIGH | Same stack. Second to develop. |
| GRIMMORPG (P&C) | Moved out | Now standalone at `E:\Unity\GRIMMORPG`. Modular stack -- Naninovel not used there. |
| P&C Game 2 (title TBD) | Moved out | Will live in its own project. |

**Docs:** [Guide](https://naninovel.com/guide/) | [API/Commands](https://naninovel.com/api/) | [FAQ](https://naninovel.com/faq/) | [VS Code Extension](https://marketplace.visualstudio.com/items?itemName=Elringus.naninovel)

---

#### ENTRY-005: Text Animator for Unity

| Field | Value |
|-------|-------|
| **Asset** | Text Animator for Unity (UI Toolkit and Text Mesh Pro) |
| **Source** | Asset Store (Febucci) |
| **Version** | 3.1.1 |
| **Category** | UI / Text Effects |
| **Date Started** | 2026-02-21 |
| **Date Completed** | 2026-02-21 |
| **Verdict** | Approved - Default |
| **Applies To** | Both (VN and P&C) |

**What It Does:**
Per-character text animation via rich text tags. Embed tags like `<shake>`, `<wave>`, `<bounce>` directly in strings and Text Animator animates individual letters (position, rotation, scale, color). Built-in typewriter system with speed control, wait actions (`<waitfor=2>`, `<waitinput>`), and event triggers (`<?shakeCamera>`). 15+ built-in effects, stackable, with inline modifiers (`<shake a=5 s=2>`). Three animation phases (Appearance, Persistent, Disappearance). Custom effects via ScriptableObject C# API. Zero GC allocations. Unity Verified Solution (Feb 2025). Won Best Artistic Tool at Unity Awards 2023. Built on TextMeshPro.

**Notable Games:** Cult of the Lamb, Dredge, Slime Rancher 2, Peglin, Little Kitty Big City, Paper Trail.

**AI-Friendliness:**
- **Best possible for AI workflows.** The entire system is tag-in-string -- AI just outputs text with embedded tags.
- Zero additional code needed to apply effects -- just include tags in dialogue strings
- Works with any dialogue system that outputs strings to TextMeshPro

**Tag Quick Reference (for AI authoring):**
```
<wave>undulating text</wave>
<shake>trembling text</shake>
<wiggle>oscillating text</wiggle>
<bounce>bouncing text</bounce>
<swing>swaying text</swing>
<pend>pendulum text</pend>
<rot>rotating text</rot>
<fade>fading text</fade>
<rainb>rainbow text</rainb>
<incr>growing text</incr>
<shake a=5 s=2>modified params</>    // amplitude=5, speed=2
<waitfor=1.5>                         // typewriter: pause 1.5s
<waitinput>                           // typewriter: wait for input
<speed=0.3>                           // typewriter: slow down
<?eventName>                          // fire C# event callback
```

**What Requires Manual Editor Work:**
- Add TextAnimator_TMP + Typewriter components to text GameObjects (one-time per UI element)
- Replace Dialogue System's default subtitle panels with TextAnimatorSubtitlePanel (one-time integration setup)
- Custom effect creation in Inspector or C# (optional)

**What I (Claude) Can Do:**
- Embed effect tags in any dialogue string -- Ink scripts, Naninovel scripts, Dialogue System text, raw C# strings
- Design tag conventions per character/emotion (e.g., angry = `<shake>`, whisper = `<fade><speed=0.3>`)
- Write custom effect ScriptableObjects in C#
- Wire up event tag handlers in C#

**Integration Points (installed):**
- Dialogue System for Unity v3.3+ -- official integration (TextAnimatorSubtitlePanel, sequencer commands TextAnimatorContinue/TextAnimatorDisappear)
- Naninovel -- partial integration (effects work, but use Naninovel's typewriter not TA's)
- Ink -- easy integration (add components, no external package needed)
- Adventure Creator -- community integration documented on AC wiki
- TextMeshPro (installed) -- required, is the rendering backend

**Docs:** [Documentation v3](https://docs.febucci.com/text-animator-unity) | [Built-in Effects](https://docs.febucci.com/text-animator-unity/effects/built-in-effects-list) | [API Reference](https://www.api.febucci.com/tools/text-animator-unity/api/Febucci.UI.Core.TAnimCore.html)

---

## Installed Package Inventory

Full list of packages in the VNPC toolkit project as of Session 1.

### Asset Store / Third-Party

| Package | Version | Category | Notes |
|---------|---------|----------|-------|
| Adventure Creator | 1.85.5 | Framework (P&C) | ENTRY-001 |
| Dialogue System for Unity | 2.2.65.1 | Dialogue / Quests | ENTRY-002 |
| DOTween Pro | 1.0.410 | Animation / Tweening | ENTRY-006 |
| Fullscreen Editor | 2.2.10 | Tools / Editor | Sandbox ENTRY-015 (Approved - Default) |
| Ink Integration for Unity | 1.1.8 | Narrative Scripting | ENTRY-003 |
| Naninovel | 1.21 | Framework (VN) | ENTRY-004 |
| Odin Inspector and Serializer | 4.0.1.3 | Tools / Editor | ENTRY-007 |
| Scriptable Sheets (LWS) | 1.8.0 | Tools / Data | Sandbox ENTRY-018 (Approved - Default) |
| Text Animator for Unity | 3.1.1 | UI / Text Effects | ENTRY-005 |
| UDebug Panel | 1.3.3 | Tools / Debug | Sandbox ENTRY-013 (Approved - Default) |
| Ultimate Preview Window | 1.3.1 | Tools / Editor | Sandbox ENTRY-006 (Approved) |
| vFavorites 2 | 2.0.14 | Tools / Editor | Sandbox ENTRY-005 (Approved) |
| vFolders 2 | 2.1.12 | Tools / Editor | Sandbox ENTRY-004 (Approved) |
| vHierarchy 2 | 2.1.7 | Tools / Editor | Sandbox ENTRY-003 (Approved) |
| Wingman | 1.2.3 | Tools / AI | Sandbox ENTRY-020 (Approved - Default) |

### Cysharp / NuGet / OpenUPM

| Package | Version | Category | Notes |
|---------|---------|----------|-------|
| UniTask | 2.5.10 (Local) | Async | Sandbox ENTRY-025 (Approved - Default) |
| R3 | 1.3.0 (NuGet) | Reactive Extensions | ENTRY-008 |
| PlayerPrefsEx (IvanMurzak) | 2.1.2 | Data / Prefs | ENTRY-009 |
| AI Game Developer -- Unity MCP | 0.48.1 | Tools / MCP | Sandbox ENTRY-056 (Approved - Default) |

### TecVooDoo

| Package | Version | Notes |
|---------|---------|-------|
| TecVooDoo Utilities | 1.0.0 (Local) | Shared utility library |

### Unity (Key Packages)

| Package | Version | Notes |
|---------|---------|-------|
| 2D Feature Set | (9 packages) | SpriteShape, Tilemap, PSD Importer, Aseprite, etc. |
| 3D Characters and Animation | (4 packages) | Animation Rigging 1.4.1, etc. |
| Gameplay and Storytelling | (3 packages) | |
| Cinemachine | 3.1.5 | Camera system |
| Input System | 1.18.0 | New input |
| Splines | 2.8.2 | Spline tools |
| Shader Graph | 17.3.0 | Custom shaders |
| Universal Render Pipeline | 17.3.0 | URP |
| ProBuilder | 6.0.9 | Mesh editing |
| Timeline | 1.8.10 | Sequencing |
| Visual Scripting | 1.9.9 | Bolt |
| Newtonsoft Json | 3.2.2 | JSON serialization |
| Burst | 1.8.27 | Compiler |
| Mathematics | 1.3.3 | Math library |

### Microsoft NuGet (MCP Dependencies)

~30+ packages: ASP.NET Core SignalR stack, CodeAnalysis (Roslyn), Extensions (DI, Logging, Hosting, Configuration), System.* utilities. All at 10.0.3 except CodeAnalysis (3.11.0/4.14.0).

---

**End of Asset Evaluation Log**
