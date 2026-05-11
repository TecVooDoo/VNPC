# VNPC - Development Reference

**Purpose:** VNPC-specific architecture and conventions. Universal rules (coding standards, refactor philosophy, session bookends, MCP/Unity gotchas, user preferences) live in the canonical docs.
**Last Updated:** May 11, 2026

---

## Canonical pointers

Universal TecVooDoo rules apply to VNPC. Read these on demand:

- **Coding Standards** -- `E:\Unity\Sandbox\Documents\Canonical\TecVooDoo_CodingStandards.md`. HOW we write code (no `var`, ASCII-only, sealed, UniTask, interfaces, no per-frame allocations, UI Toolkit, New Input System, etc.). This file overrides any drift in project docs.
- **Universal Workflow** -- `E:\Unity\Sandbox\Documents\Canonical\UniversalWorkflow.md`. HOW we work in a session (bookends, commit ownership, refactor philosophy, MCP/Unity gotchas, user preferences, rule classification). This file overrides any drift in project docs.
- **MCP state and upgrade recipes** -- `E:\Unity\Sandbox\Documents\Canonical\MCP_ConnectionBrief.md`.

When the canonical docs change, the change shows in each doc's Revision History header at the top.

---

## VNPC-Specific Architecture

### Namespaces

| Namespace | Purpose | Status |
|-----------|---------|--------|
| `Naninovel` (vendored) | Visual novel engine | Installed |
| `Febucci.UI` (vendored) | Text Animator | Installed |
| `PixelCrushers.DialogueSystem` (vendored) | Dialogue System | Installed (for shared logic) |
| `VNPC.TextAnimatorIntegration` | Custom Naninovel + TA bridge | 1 script -- `TATextPrinterPanel.cs` |

### Assembly Definitions

| Assembly | Namespace | Platform | References |
|----------|-----------|----------|------------|
| `VNPC.TextAnimatorIntegration` | (same) | Both | Naninovel, TextAnimator |

### Folder Structure

```
Assets/
  VNPC/                          -- toolkit code (extension scripts, shared utilities)
  _VNPC/                         -- per-game assets
    Games/
      GITT/                      -- Genie in a Test Tube
        Audio/SFX/               -- pre-Phase-5 audio drop (currently being reorganized)
  Scenario/                      -- Naninovel .nani scripts (16 GITT scenes + Entry + Transition)
  NaninovelData/                 -- Naninovel runtime data + Resources
```

### Dependencies (Active for VN Scope)

| Dependency | Used By | Notes |
|------------|---------|-------|
| Naninovel | GITT, EF | Visual novel engine |
| Text Animator | GITT, EF | Per-character text effects via rich-text tags |
| Dialogue System | Cross-game shared logic | Optional for VN -- reserved for shared barks/logs |
| Odin Inspector | Editor tooling | Custom inspectors, serialization |
| UniTask | Async operations | Async/await for Unity |
| DOTween Pro | Tweening | UI/menu transitions |

P&C-only assets (Adventure Creator, Ink Integration) remain installed for historical reference but are not used by VNPC's two VN games. GRIMMORPG and P&C Game 2 moved to standalone projects.

---

## VNPC-Specific Refactor Notes

Universal refactor philosophy is in `UniversalWorkflow.md`. No VNPC-specific deviations yet -- the project has only 1 custom script.

---

## Spatial Convention

VNPC is a screen-space VN project. No 3D scene architecture; Naninovel handles positioning of actors/backgrounds via its own pos:/x: parameter system. Per Scene 2.6-2.7 playtesting, character positions Doctor:30 / Hanna:50 / Nurse:70 are the validated three-actor layout.

---

## Script Inventory

1 custom script.

| Script | Lines | Namespace | Role |
|--------|-------|-----------|------|
| `TATextPrinterPanel.cs` | ~ | `VNPC.TextAnimatorIntegration` | Extends Naninovel `UITextPrinterPanel`; routes reveal through Text Animator via `SetVisibilityChar` so TA tags (`<wave>`, `<shake>`, `<bounce>`, `<wiggle>`) survive Naninovel's parser |

Full API: `VNPC_CodeReference.md`.

---

## Lessons Learned

- **Naninovel "Initialize On Application Load" must be unchecked** when testing non-Naninovel scenes in the project. (Historical -- mattered when GRIMMORPG/AC scenes lived here; now mostly irrelevant since P&C moved out.)
- **TA tags survive Naninovel's parser intact** -- `<wave>`, `<shake>`, `<bounce>` pass through the Naninovel script tokenizer unmodified because TA uses `<` as a tag-open and Naninovel only intercepts `@`/`[`-prefixed commands.
- **Mouse click doesn't advance dialogue** by default in Unity 6 with the new Input System -- Naninovel maps Continue to scroll wheel + Enter. Rebind via `DefaultControls.inputactions` in Phase 7 polish.
- **One `.mcp.json` only** -- a duplicate at the project root previously caused zombie `unity-mcp-server.exe` processes and double-server spawns. Keep it at `.claude/mcp.json` only.

---

## Session Workflow

Universal bookend rules are in `UniversalWorkflow.md` § Session Bookends. The condensed VNPC view:

**Session open:**
1. Read `VNPC_Status.md` for current state.
2. Verify Unity reachable via MCP (server on port 52724).
3. Check Console -- expect 0 errors before starting work.

**Session close (per UniversalWorkflow.md v1.1 doc-update checklist):**
1. `VNPC_Status.md` -- always touched (append session entry).
2. `VNPC_StatusArchive.md` -- if Status grows past ~250 lines, roll oldest entries.
3. `VNPC_CodeReference.md` -- if namespaces / public API changed.
4. `VNPC_DevReference.md` -- if project-specific architecture changed.
5. Memory entries for session-spanning lessons.
6. Commit + push to `origin/main` on `TecVooDoo/VNPC`.
7. `git status` must be clean after push (hard invariant). Surface deliberate carryovers to the user.

---

**End of Development Reference**
