# VNPC - Code Reference

Purpose: API reference for the VNPC codebase. Per-script entries with serialized fields, public API, usage notes, and gotchas. Check this before writing new code to avoid referencing non-existent classes or methods.

Last Updated: 2026-05-11 (post-crash recovery audit; package versions refreshed, scope narrowed to VN stack)

---

## Table of Contents

1. [Assembly Definitions](#assembly-definitions)
2. [Namespaces Overview](#namespaces-overview)
3. [Custom Scripts](#custom-scripts)
4. [Input Actions](#input-actions)
5. [Scene Structure](#scene-structure)
6. [Dependencies Reference](#dependencies-reference)
7. [File Locations](#file-locations)

---

## Assembly Definitions

| Assembly | Root Namespace | References | Notes |
|----------|---------------|------------|-------|
| `VNPC.TextAnimatorIntegration` | `VNPC.TextAnimatorIntegration` | Naninovel, TextAnimator | Bridge asmdef. Hosts `TATextPrinterPanel`. |

(No-asmdef scripts fall into `Assembly-CSharp`. None currently.)

---

## Namespaces Overview

| Namespace | Assembly | Purpose | Status |
|-----------|----------|---------|--------|
| `VNPC.TextAnimatorIntegration` | `VNPC.TextAnimatorIntegration` | Custom Naninovel + Text Animator bridge | Active (1 script) |

---

## Custom Scripts

### `TATextPrinterPanel.cs`

- **Namespace:** `VNPC.TextAnimatorIntegration`
- **Inherits:** `Naninovel.UITextPrinterPanel`
- **Role:** Replaces the default Naninovel text printer with one that drives a Text Animator typewriter. Routes the reveal through `SetVisibilityChar` so per-character TA effects (`<wave>`, `<shake>`, `<bounce>`, `<wiggle>`) survive the script-to-screen pipeline.
- **Prefab:** `Assets/NaninovelData/Resources/Naninovel/TextPrinters/TADialogue.prefab` (built by duplicating Naninovel's `Dialogue` printer and swapping the panel script).
- **Registered in:** `TextPrintersConfiguration` (set as default printer for the project).

---

## Input Actions

Naninovel ships with `DefaultControls.inputactions`. Known issue: mouse click does not advance dialogue under the new Input System -- Naninovel binds Continue to scroll wheel and Enter, not left-click. Rebind in Phase 7 polish.

---

## Scene Structure

GITT runs entirely inside Naninovel's runtime scene. Scripts:

```
Assets/Scenario/
  GITT_Entry.nani                    -- routes to Scene1_1
  GITT_SyntaxTest.nani               -- Phase 0 validation
  GITT_TATest.nani                   -- Phase 1 TA validation
  GITT_Phase2Test.nani               -- Phase 2 actor/background validation
  Scene1_1_HolographicHorse.nani     -- Act 1
  Scene1_2 ... Scene1_8              -- Act 1 (8 scenes total)
  Transition.nani                    -- between acts
  Scene2_1_MatsConfession.nani       -- Act 2
  Scene2_2 ... Scene2_7              -- Act 2 (7 scenes total)
```

Total: 16 .nani story scripts + Entry + 3 test scripts.

---

## Dependencies Reference

### Core (VN stack, active)

| Package | Version | Purpose | Docs |
|---------|---------|---------|------|
| Naninovel | 1.21 | Visual novel engine (.nani scripts, actors, backgrounds, choices, save/load, rollback) | [Guide](https://naninovel.com/guide/) |
| Text Animator | 3.1.1 | Per-character text animation via rich text tags, typewriter system | [Docs v3](https://docs.febucci.com/text-animator-unity) |
| Dialogue System for Unity | 2.2.65.1 | Dialogue, quests, barks -- reserved for cross-game shared logic | [Manual 2.x](https://www.pixelcrushers.com/dialogue_system/manual2x/html/) |

### P&C-Only (installed but not used by VNPC games)

| Package | Version | Notes |
|---------|---------|-------|
| Adventure Creator | 1.85.5 | P&C framework. Used by GRIMMORPG (standalone project). Kept installed for cross-eval reference. |
| Ink Integration | 1.1.8 | Narrative scripting. P&C-side use. |

### Animation / Tweening

| Package | Version | Purpose |
|---------|---------|---------|
| DOTween Pro | 1.0.410 | Programmatic tweening/animation |
| Animation Rigging | 1.4.1 | Runtime rigging constraints |

### Tools / Editor

| Package | Version | Purpose |
|---------|---------|---------|
| Odin Inspector | 4.0.1.3 | Custom editor tooling, serialization, inspector enhancement |
| Scriptable Sheets (LWS) | 1.8.0 | Spreadsheet-based SO data management |
| UDebug Panel | 1.3.3 | Runtime debugging tools |
| Ultimate Preview Window | 1.3.1 | Asset preview in editor |
| Fullscreen Editor | 2.2.10 | Editor fullscreen mode |
| vFavorites 2 | 2.0.14 | Editor favorites |
| vFolders 2 | 2.1.12 | Editor folder icons |
| vHierarchy 2 | 2.1.7 | Editor hierarchy enhancements |
| Wingman | 1.2.3 | AI assistant integration |
| AI Game Developer -- Unity MCP | 0.72.0 | MCP bridge for Claude Code (upgraded 2026-05-11 from 0.66.1 via universal direct-jump recipe) |

### Architecture / Data

| Package | Version | Purpose |
|---------|---------|---------|
| UniTask | 2.5.10 (Local) | Async/await for Unity |
| R3 | 1.3.0 (NuGet) | Reactive extensions |
| PlayerPrefsEx | 2.1.2 | Enhanced player prefs |
| Unity-Theme | Local (cloned) | Centralized color palettes, runtime theme switching, UI binders |
| Unity-ImageLoader | Local (cloned) | Async image loading with dual-layer cache, portrait/CG display |
| TecVooDoo Utilities | 1.0.0 (Local) | Shared utility library |

### Unity Core

| Package | Version | Purpose |
|---------|---------|---------|
| URP | 17.3.0 | Render pipeline |
| Cinemachine | 3.1.5 | Camera system |
| Input System | 1.18.0 | New input |
| Splines | 2.8.2 | Spline tools |
| Shader Graph | 17.3.0 | Custom shaders |
| ProBuilder | 6.0.9 | Mesh editing |
| Timeline | 1.8.10 | Sequencing |
| Newtonsoft Json | 3.2.2 | JSON serialization |

Full eval entries (where applicable): `VNPC_AssetLog.md`

---

## File Locations

```
Assets/
  VNPC/
    TextAnimatorIntegration/       -- asmdef + TATextPrinterPanel.cs
  _VNPC/Games/GITT/                -- per-game assets (Audio, etc.)
  Scenario/                        -- 16 .nani GITT scripts + Entry + tests
  NaninovelData/
    Resources/Naninovel/
      TextPrinters/TADialogue      -- custom printer prefab
      Configuration/               -- engine config assets
```

---

**End of Code Reference**
