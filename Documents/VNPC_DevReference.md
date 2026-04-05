# VNPC - Development Reference

**Purpose:** Stable reference for VNPC architecture, coding standards, and conventions. Read on demand, not every session.
**Last Updated:** February 21, 2026

---

## Architecture

### Namespaces

| Namespace | Purpose | Status |
|-----------|---------|--------|
| (pending architecture decisions) | | |

### Assembly Definitions

| Assembly | Namespace | Platform | References |
|----------|-----------|----------|------------|
| (none yet) | | | |

### Folder Structure

```
Assets/VNPC/
  (pending -- will be established once core architecture is decided)
```

### Dependencies (External)

| Dependency | Used By | Notes |
|------------|---------|-------|
| Odin Inspector | Editor tooling | Custom inspectors, serialization |
| UniTask | Async operations | Async/await for Unity |
| ScriptableSheets | Data management | Spreadsheet-based SO editing |

---

## Coding Standards

(To be established -- carry forward from project conventions once decided)

### Refactoring Rules

**Golden rule:** Don't refactor for the sake of refactoring. Priority order: Memory > SOLID > Self-documenting > Clean > Reusability.

**When TO refactor:** > 1200 lines AND has separable responsibilities, repeated code patterns across 3+ files, performance bottleneck identified by profiling, API is confusing to use correctly.

**When NOT TO refactor:** To hit a line count target, single-use helpers, code that is cohesive and naturally together, "might need it later" abstractions, during a feature milestone (do between milestones).

| Line Count | Action |
|------------|--------|
| < 500 | Leave alone unless clear SRP violation |
| 500-800 | Monitor, no action needed |
| 800-1200 | OPTIMAL |
| 1200-1500 | Review for extraction opportunities |
| > 1500 | Strong refactor candidate |

### Memory Efficiency

Zero-allocation hot paths required:

- **No per-frame allocations:** No `new List<T>()`, no string `+` concat, no LINQ, no `.ToArray()`/`.ToList()` in Update/FixedUpdate
- **No per-action allocations:** No allocations per click, per dialogue advance, per scene transition
- **Reuse collections:** Pool frequent lists, use `Array.Empty<T>()` for empty returns, pre-allocate when size is known
- **String efficiency:** `StringBuilder` for multi-part building, cache formatted strings, no string parsing in hot paths

### Development Priorities

1. Use installed assets first -- before writing custom code
2. SOLID principles
3. Memory efficiency -- zero-allocation hot paths, object pooling where appropriate
4. Self-documenting code -- clear naming over comments
5. Platform best practices -- Unity > C#

---

## Spatial Convention

(To be established once scene architecture is decided)

---

## Script Inventory

0 scripts, 0 total lines. Full API: `VNPC_CodeReference.md`.

| Script | Lines | Namespace | Role |
|--------|-------|-----------|------|
| (none yet) | | | |

---

## Lessons Learned

(To be populated as development progresses)

---

**End of Development Reference**
