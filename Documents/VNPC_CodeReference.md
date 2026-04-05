# VNPC - Code Reference

Purpose: Complete API reference for the VNPC codebase. Per-script entries with serialized fields, public API, usage notes, and gotchas. Check this before writing new code to avoid referencing non-existent classes or methods.

Last Updated: 2026-02-21 (Session 1. Project initialized, all packages installed, no custom scripts yet.)

---

## Table of Contents

1. [Assembly Definitions](#assembly-definitions)
2. [Namespaces Overview](#namespaces-overview)
3. [Input Actions](#input-actions)
4. [Scene Structure](#scene-structure)
5. [Dependencies Reference](#dependencies-reference)
6. [File Locations](#file-locations)

---

## Assembly Definitions

| Assembly | Root Namespace | References | GUID |
|----------|---------------|------------|------|
| (none yet) | | | |

---

## Namespaces Overview

| Namespace | Assembly | Purpose | Status |
|-----------|----------|---------|--------|
| (none yet) | | | |

---

## Input Actions

(Not yet configured)

---

## Scene Structure

(Not yet established)

---

## Dependencies Reference

### Core Frameworks

| Package | Version | Purpose | Docs |
|---------|---------|---------|------|
| Adventure Creator | 1.85.5 | Point-and-click framework (ActionLists, navigation, inventory, cameras, save/load) | [Scripting Guide](https://adventurecreator.org/scripting-guide/) |
| Dialogue System for Unity | 2.2.65.1 | Dialogue, quests, barks, cutscene sequencer, Lua scripting | [Manual 2.x](https://www.pixelcrushers.com/dialogue_system/manual2x/html/) |
| Ink Integration | 1.1.8 | Narrative scripting language (.ink plain-text files, auto-compile to JSON) | [Writing with Ink](https://github.com/inkle/ink/blob/master/Documentation/WritingWithInk.md) |
| Naninovel | 1.21 | Visual novel engine (.nani scripts, actors, backgrounds, choices, save/load, rollback) | [Guide](https://naninovel.com/guide/) |
| Text Animator | 3.1.1 | Per-character text animation via rich text tags, typewriter system | [Docs v3](https://docs.febucci.com/text-animator-unity) |

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
| AI Game Developer -- Unity MCP | 0.48.1 | MCP bridge for Claude Code |
| MCP Animation Extension | 1.0.24 | 6 MCP tools for animation/animator inspection |
| MCP ProBuilder Extension | 1.0.24 | 13 MCP tools for ProBuilder mesh editing |

### Architecture / Data

| Package | Version | Purpose |
|---------|---------|---------|
| UniTask | 2.5.10 (Local) | Async/await for Unity |
| R3 | 1.3.0 (NuGet) | Reactive extensions |
| PlayerPrefsEx | 2.1.2 | Enhanced player prefs |
| Unity-Theme | Local (cloned) | Centralized color palettes, runtime theme switching, 14+ UI binders |
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
| 2D Feature Set | (9 packages) | SpriteShape, Tilemap, PSD Importer, Aseprite |

Full package inventory: `VNPC_AssetLog.md`

---

## File Locations

```
Assets/VNPC/
  (folder structure pending architecture decisions)
```

---

**End of Code Reference**
