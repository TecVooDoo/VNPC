# VNPC Toolkit -- Game Design Document

**Developer:** TecVooDoo LLC
**Platform:** PC
**Engine:** Unity 6 (URP)
**Toolkit Scope:** 4 games (2 VN, 2 P&C) sharing a common codebase

**Document Version:** 0.3
**Last Updated:** February 21, 2026

---

## Release Strategy

VN and P&C titles serve as **teasers/backstory drops** before their corresponding larger games (3D/2.5D/2D full releases). The short-form games build audience and establish narrative context.

| Dev Order | Working Title | Type | Source Material | Status | Stack | GDD |
|-----------|---------------|------|-----------------|--------|-------|-----|
| 1 | **Genie in a Test Tube** | Visual Novel | "Genie in a Test Tube" (short story, complete) | GDD v0.1 drafted | Naninovel + Text Animator | `GITT_GDD.md` |
| 2 | **Encapsulated Fear** | Visual Novel | "Encapsulated Fear: A Short Tail" (short story, complete) | GDD v0.1 drafted | Naninovel + Text Animator | `EF_GDD.md` |
| 3 | (TBD) | Point and Click | (in editing) | Source in editing | AC + Dialogue System + Ink + Text Animator | `PNC1_GDD.md` |
| 4 | (TBD) | Point and Click | (being written) | Source being written | AC + Dialogue System + Ink + Text Animator | `PNC2_GDD.md` |

**Source material location:** `E:\TecVooDoo\Projects\Writing\`

---

## Table of Contents

1. [Shared Design Pillars](#shared-design-pillars)
2. [Shared Mechanics](#shared-mechanics)
3. [Per-Game GDDs](#per-game-gdds)
4. [Design Decisions](#design-decisions)

---

## 1. Shared Design Pillars

(To be defined -- principles that apply across all 4 games)

---

## 2. Shared Mechanics

These systems are built once in the toolkit and reused across games.

### 2.1 Dialogue / Text Presentation
- Text Animator tags for emotion/emphasis (shared tag vocabulary across all 4 games)
- Typewriter with pacing control (`<waitfor>`, `<speed>`, `<waitinput>`)
- Event tags for audio/animation triggers (`<?shakeCamera>`, `<?playSound>`)

### 2.2 Save/Load
- (To be designed -- likely leveraging framework-native systems: Naninovel save for VNs, AC save for P&C)

### 2.3 UI Theme System
- Unity-Theme for per-game color palettes with shared UI prefabs
- Unity-ImageLoader for async portrait/CG loading

### 2.4 Settings
- (To be designed -- shared settings UI across games)

---

## 3. Per-Game GDDs

| File | Game | Status |
|------|------|--------|
| `GDD/GITT_GDD.md` | Genie in a Test Tube (VN) | v0.1 -- story read, scenes broken down, art/audio requirements listed, open decisions flagged |
| `GDD/EF_GDD.md` | Encapsulated Fear (VN) | v0.1 -- story read, scenes broken down, art/audio requirements listed, open decisions flagged |
| `GDD/PNC1_GDD.md` | P&C Game 1 (TBD) | Not started -- source in editing |
| `GDD/PNC2_GDD.md` | P&C Game 2 (TBD) | Not started -- source being written |

---

## 4. Design Decisions

| # | Decision | Status | Session |
|---|----------|--------|---------|
| 1 | Toolkit project -- shared codebase for 4 games (2 VN, 2 P&C) | Locked | S1 |
| 2 | VN stack: Naninovel + Text Animator + Dialogue System | Locked | S1 |
| 3 | P&C stack: Adventure Creator + Dialogue System + Ink + Text Animator | Locked | S1 |
| 4 | VN/P&C releases are teasers/backstory before larger full games | Locked | S1 |
| 5 | Two VN source stories complete: "Encapsulated Fear" and "Genie in a Test Tube" | Noted | S1 |
| 6 | GITT is first to develop (shorter, tighter structure, good trial run) | Locked | S2 |
| 7 | Source stories read and per-game GDDs drafted (v0.1) | Noted | S2 |

---

**End of GDD**
