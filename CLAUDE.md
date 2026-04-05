# Visual Novel Point and Click (VNPC) -- Project Instructions

## Project Overview

Shared toolkit project for visual novel and point-and-click adventure games. Built in Unity 6, URP. Base for 4 planned games (2 VN, 2 P&C).

**Developer:** TecVooDoo LLC / Rune (Stephen Brandon)
**Repo:** (not yet initialized)

## Quick Start

- **"Where are we at?"** -> Read `Documents/VNPC_Status.md`
- **Script API** -> Read `Documents/VNPC_CodeReference.md`
- **Architecture/standards** -> Read `Documents/VNPC_DevReference.md`
- **Game design** -> Read `Documents/GDD/VNPC_GDD.md`
- **Asset evaluations** -> Read `Documents/VNPC_AssetLog.md`

## Code Conventions (MANDATORY)

- **Use installed assets first** -- before writing custom code, check if an installed package already provides the functionality
- **No `var`** -- explicit types always
- **No per-frame allocations or LINQ in Update/FixedUpdate**
- **ASCII only** in docs, comments, and identifiers
- **File targets:** 800-1200 lines per script

## Assembly Structure

```
(To be established once core architecture is decided)
```

## MCP

- `com.ivanmurzak.unity.mcp` via OpenUPM
- **script-execute is the power tool** -- Roslyn for all non-trivial scene setup
- C# `<>` and `&&` get HTML-encoded in MCP -- use `typeof()` casts and nested if-statements
- Roslyn scripts don't auto-persist -- call `.Save()` / `SetDirty()` / `SaveAssets()`
- MCP disconnects during domain reload -- wait for auto-reconnect

## Critical Gotchas

- **UPM Git URLs don't work on this machine** -- clone repo, use `file:` reference in manifest.json
- **asmdef visibility** -- no-asmdef = Assembly-CSharp. Named asmdef can't see Assembly-CSharp
- **Serialized field defaults** -- changing defaults does NOT update existing instances. Remove+re-add component or Reset

## User Preferences

- Direct, honest assessments -- no sugarcoating
- Design-first: research -> GDD -> implementation
- Production-quality code even in prototype stages
- **One doc interface:** "where are we at" or "update" -> VNPC_Status.md
- **GDD is user's doc** -- update only when asked
- **Proactive flagging:** If a process/tool/workflow breaks, say so immediately
