# Visual Novel Point and Click (VNPC) -- Project Instructions

## Project Overview

Shared toolkit project for visual novel games. Built in Unity 6 (6000.3.15f1), URP. Base for 2 planned VN games (GITT, EF). The two P&C games moved to standalone projects in April 2026 (GRIMMORPG at `E:\Unity\GRIMMORPG`, P&C Game 2 source still being written).

**Developer:** TecVooDoo LLC / Rune (Stephen Brandon)
**Project root:** `E:\Unity\VisualNovelPointClick\`
**Repo:** `TecVooDoo/VNPC` on GitHub (origin/main)

## Quick Start

- **"Where are we at?"** -> Read `Documents/VNPC_Status.md`
- **Script API** -> Read `Documents/VNPC_CodeReference.md`
- **Architecture/standards** -> Read `Documents/VNPC_DevReference.md`
- **Game design** -> Read `Documents/GDD/VNPC_GDD.md`
- **Asset evaluations** -> Read `Documents/VNPC_AssetLog.md`

## Code Conventions

Universal TecVooDoo coding standards: see `E:\Unity\Sandbox\Documents\Canonical\TecVooDoo_CodingStandards.md` (canonical, single source of truth across the fleet).

VNPC-specific additions:
- **Use installed assets first** -- before writing custom code, check if an installed package already provides the functionality (Naninovel, Text Animator, Dialogue System).

## Assembly Structure

```
(To be established once core architecture is decided)
```

## MCP

- `com.ivanmurzak.unity.mcp` via OpenUPM. Current: **0.72.0**, transport `streamableHttp`, port `52724`.
- Cross-fleet state and upgrade recipes live in `E:\Unity\Sandbox\Documents\Canonical\MCP_ConnectionBrief.md`.
- Universal MCP gotchas (HTML encoding, lambda 500s, NativeArray crashes, etc.) are in `E:\Unity\Sandbox\Documents\Canonical\UniversalWorkflow.md` § Universal MCP Gotchas.

## VNPC-Local Gotchas

- **UPM Git URLs don't work on this machine** -- clone repo, use `file:` reference in `manifest.json`.
- **asmdef visibility** -- no-asmdef = Assembly-CSharp. Named asmdef can't see Assembly-CSharp.
- **Serialized field defaults** -- changing defaults does NOT update existing instances. Remove+re-add component or Reset.

## User Preferences

- Direct, honest assessments -- no sugarcoating
- Design-first: research -> GDD -> implementation
- Production-quality code even in prototype stages
- **One doc interface:** "where are we at" or "update" -> VNPC_Status.md
- **GDD is user's doc** -- update only when asked
- **Proactive flagging:** If a process/tool/workflow breaks, say so immediately
