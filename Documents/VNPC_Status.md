# VNPC - Project Status

**Project:** Visual Novel Point and Click (VNPC) -- Shared Toolkit Project
**Platform:** Unity 6, URP
**VNPC Root:** `Assets/VNPC/`
**GDD:** v0.3
**Codebase:** 0 scripts
**Repo:** TecVooDoo/VNPC (GitHub)
**Scope:** Visual novel games (GITT, EF). P&C games moved to dedicated projects.

**Reference docs:** `VNPC_DevReference.md` (architecture, standards, lessons), `VNPC_CodeReference.md` (script API), `VNPC_AssetLog.md` (asset evaluations)

---

## Current Work

**GITT Phase 4 (Text Animator Polish) complete.** Emotional text effects applied across all 16 scenes. Conservative pass: shake (anger/threats/pain), wave (wonder/revelation/tenderness), bounce (humor/excitement), wiggle (unease/discomfort). Playtested start-to-finish, no errors. Ready for Phase 5 (Audio).

**GRIMMORPG moved to standalone project** at `E:\Unity\GRIMMORPG`. Adventure Creator dropped after practical eval; modular stack adopted. See GRIMMORPG project docs for current status.

**2D Background Pipeline validated.** PolyPerfect/Synty 3D assets assembled in Unity scene, rendered via camera to 1920x1080 PNG. No Blender needed. First output: `Assets/_VNPC/Games/_GRIMMORPG/Backgrounds/BeatriceRoom_BG.png`. (Note: with 2.5D switch, pre-rendered backgrounds may no longer be needed -- 3D scenes are used directly.)

**Compile status:** Clean. 1 custom script (TATextPrinterPanel.cs) + 1 asmdef.

**MCP status:** Installed (v0.48.1), connected via stdio (transportMethod: 1, keepServerRunning: false, port: 52724). Stable connection.

**Asset stacks evaluated and approved:**
- **VN stack:** Naninovel + Text Animator (+ Dialogue System for cross-game shared logic)
- **P&C stack:** Adventure Creator + Dialogue System + Ink + Text Animator
- **Shared:** DOTween Pro, Odin Inspector, UniTask, R3, all editor/QoL tools

**Game lineup (this project):**
1. **Genie in a Test Tube** (VN) -- GDD v0.2, design decisions locked, Phase 4 complete (greybox + TA polish)
2. **Encapsulated Fear** (VN) -- GDD v0.1 drafted, second to develop

**Other games (separate projects):**
- **GRIMMORPG** (P&C) -- standalone at `E:\Unity\GRIMMORPG`
- **P&C Game 2** (title TBD) -- source being written

**Phase 0 -- Foundation and Learning -- COMPLETE**
- [x] Folder structure created (`Assets/VNPC/Shared/`, `Assets/VNPC/Games/GITT/`)
- [x] Syntax validation script written (`Assets/Scenario/GITT_SyntaxTest.nani`)
- [x] Run existing Naninovel samples (Entry.nani) in Unity Editor
- [x] Import Visual Novel sample from Package Manager
- [x] Run GITT_SyntaxTest.nani -- all 18 command tests passed, no errors

**Phase 1 -- Text Animator Integration -- COMPLETE**
- [x] Assembly definition created (`VNPC.TextAnimatorIntegration.asmdef`)
- [x] Custom printer panel written (`TATextPrinterPanel.cs` extends UITextPrinterPanel)
- [x] TADialogue prefab built (duplicated Dialogue, swapped to TA pipeline)
- [x] Registered TADialogue in TextPrintersConfiguration
- [x] GITT_TATest.nani -- all effects work (wave, shake, bounce, wiggle), no console errors
- [x] Tag survival confirmed -- `<wave>`, `<shake>`, `<bounce>` tags pass through Naninovel parser intact

**Phase 2 -- Character and World Setup -- COMPLETE**
- [x] Registered 4 characters: Hanna (8 appearances), Matt (8 appearances), Nurse (2 appearances), Doctor (2 appearances)
- [x] Registered 4 backgrounds: Office, OperatingRoom, OperatingRoomRevealed, Black (+ default MainBackground)
- [x] GITT_Phase2Test.nani -- all characters, appearances, backgrounds validated

**Phase 3 -- Script Adaptation -- COMPLETE**
- [x] Script conventions doc written (`Documents/GITT_ScriptConventions.md`)
- [x] Act 1: 8 scenes (Scene1_1 through Scene1_8) -- ~600 lines total
- [x] Transition: 1 scene -- ~57 lines
- [x] Act 2: 7 scenes (Scene2_1 through Scene2_7) -- ~500 lines total
- [x] Entry script (GITT_Entry.nani) -- routes to Scene1_1
- [x] All appearance references validated against registered character configs
- [x] Scene chain verified: Entry → 1.1 → 1.2 → … → 1.8 → Transition → 2.1 → … → 2.7 → @stop

**Needs next:**
- Phase 5: Audio integration (SFX files ready, need to wire @sfx commands + source music)
- Phase 6: Art integration (after greybox prototype is locked)
- Phase 7: UI, polish, and ship

---

## Sessions

**Session 1 (Feb 21, 2026):** Project created. Unity 6 URP project at `E:\Unity\VNPC\VisualNovelPointClick`. Core documents established (Status, DevReference, CodeReference, GDD, AssetLog). All packages imported: Adventure Creator 1.85.5, Dialogue System 2.2.65.1, Ink Integration 1.1.8, Naninovel 1.21, Text Animator 3.1.1, DOTween Pro, Odin Inspector 4.0.1.3, R3, PlayerPrefsEx, MCP Animation/ProBuilder extensions, Unity-Theme, Unity-ImageLoader, plus full editor/QoL toolkit. MCP installed (0.48.1) and connected via stdio. Deep-dive evaluation of 5 core narrative/adventure assets completed with AI-friendliness assessment. Two architecture stacks identified: VN (Naninovel-led) and P&C (AC + Dialogue System + Ink). Game lineup established: 2 VNs from completed short stories ("Encapsulated Fear", "Genie in a Test Tube"), 2 P&C games (sources in progress). Release strategy: VN/P&C drops as teasers before larger full games.

**Session 2 (Feb 21, 2026):** Source stories read ("Encapsulated Fear: A Short Tail" ~7,600 words, "Genie in a Test Tube" ~5,000 words). Per-game GDDs drafted: GITT_GDD.md (v0.1) and EF_GDD.md (v0.1). Each GDD includes story summary, character profiles with sprite/expression requirements, location breakdowns, full scene-by-scene structure, art requirements (sprites, backgrounds, CGs), audio requirements (music tracks, SFX), UI/UX notes, and open design decisions. GITT selected as first to develop (shorter, cleaner two-act structure, good trial for the VN pipeline). Toolkit GDD updated to v0.3 with dev order and cross-references.

**Session 3 (Feb 21, 2026):** Phase 0 and Phase 1 completed. Phase 0: Fixed Naninovel config issues (Disable Rendering, Disable Input, Spawn Event System, Active Input Handling), ran GITT_SyntaxTest.nani successfully with all 18 command tests passing. Phase 1: Built Text Animator + Naninovel integration -- custom TATextPrinterPanel.cs (extends UITextPrinterPanel, uses SetVisibilityChar for reveal), assembly definition (VNPC.TextAnimatorIntegration), TADialogue prefab, and GITT_TATest.nani. All TA effects (wave, shake, bounce, wiggle) confirmed working with no console errors. TA tags survive Naninovel's script parser intact. Next: Phase 2 (character and background registration).

**Session 4 (Mar 9, 2026):** Full Sandbox-depth asset evaluations completed for Adventure Creator (ENTRY-001) and Naninovel (ENTRY-004) in VNPC_AssetLog.md. Both entries upgraded from light evaluations to comprehensive format matching Sandbox ENTRY-251 standard. AC: 675 scripts, ~56K LOC, 126 Actions, 8 Managers, 54-script save system. Naninovel: 902 scripts, ~25K LOC, 95 Commands, 11 actor types, 23 configurations, 27 UI subsystems. Naninovel added to Sandbox AssetLog as ENTRY-273.

**Session 5 (Mar 9, 2026):** Phase 2 and Phase 3 completed. Phase 2: Registered all GITT characters (Hanna, Mat, Nurse, Doctor) with story-specific appearances (20 total) and backgrounds (Office, OperatingRoom, OperatingRoomRevealed, Black). Phase2Test validated all actors. Phase 3: Full story adapted into 16 .nani scripts (8 Act 1, 1 Transition, 7 Act 2) plus GITT_Entry.nani. Script conventions doc created. All appearance references validated. Greybox prototype is complete — full game playable start-to-finish with placeholder visuals. Playtesting fixes: added @hide Mat after kick scene, fixed pos:20/80 off-screen to pos:30/70, added character fadeouts at ending, fixed Nurse/Doctor positioning in Scenes 2.6-2.7 (Doctor:30 left, Hanna:50 center, Nurse:70 right). Known issue: mouse click doesn't advance dialogue (Naninovel maps Continue to scroll wheel by default in Unity 6 new input system); Enter key and scroll wheel work fine.

**Session 6 (Mar 23, 2026):** GITT art asset list created (Documents/GITT_ArtAssetList.md) for artist handoff — 6 sprite bases, 20 expressions, 3-4 backgrounds, 6 CGs, optional UI elements. MCP tools tested and confirmed working across all 4 groups (nani-*, ac-*, ta-*, ink-*). Fixed MCP .mcp.json config (duplicate file was causing connection issues). Adventure Creator set up for GRIMMORPG: initial manual setup failed (camera, input, NavMesh wiring issues — lesson: always use AC's New Game Wizard). Rebuilt via New Game Wizard with 2D perspective, Point And Click, Nine Verbs interface. Working AC scene at Assets/_VNPC/Games/_GRIMMORPG. GRIMMORPG GDD v0.1 drafted — protagonist renamed from Mary to Beatrice (Dante's Divine Comedy parallel), core mechanics defined: tech vs magic tradeoff, grimoire pages as collectible spine, computer-amplified spellcasting, possessed influencer antagonists. Naninovel "Initialize On Application Load" must be unchecked when testing AC scenes.

**Session 7 (Mar 26, 2026):** MCP housekeeping session. Removed duplicate `.mcp.json` from `VisualNovelPointClick/` (was causing zombie `unity-mcp-server.exe` processes and double server spawns). Added Blender MCP to project config. Tested Adobe MCP (Photoshop/Illustrator) but removed — requires separate proxy server (`localhost:3001`) and adds complexity not needed yet. Final config: Unity (port 52724) + Blender (port 9876). Discussed using 3D assets (Synty library, PolyPerfect) as pre-rendered 2D sprites/backgrounds for all games.

**Session 8 (Mar 27, 2026):** 2D background art pipeline validated end-to-end. Built Beatrice's room scene (`Assets/_VNPC/Games/_GRIMMORPG/Scenes/BeatriceRoom.unity`) using PolyPerfect Low Poly Ultimate Pack + Poly Universal Pack modular pieces. Room structure: Poly Universal Pack interior walls (3m, with door and window), floor, ceiling -- textured out of the box. Furniture/props: gaming desk, dual monitors, gaming PC, gaming chair, bookshelf, LED panels, moving boxes, pizza box, teddy bear, coffee machine, etc. PolyPerfect prefabs required URP material import (`URP_LowPolyUltimatePack.unitypackage`). Rendered to 1920x1080 PNG via Roslyn script (camera render to RenderTexture, encode to PNG). Output at `Assets/_VNPC/Games/_GRIMMORPG/Backgrounds/BeatriceRoom_BG.png`. Pipeline: build 3D scene in Unity with asset library props, position camera, render to PNG. No Blender round-trip needed. Synty packs (11 indexed) also available for future rooms. Memory consolidated from parent folder to correct project path.

**Phase 4 (TA Polish) also completed this session.** Text Animator effects applied to all 16 .nani scripts -- conservative pass with shake (anger/threats), wave (wonder/tenderness), bounce (humor), wiggle (unease). Playtested full game, no errors.

Character art pipeline also validated. Compared PolyPerfect Animated People (bone-driven face, 6 preset expressions, single atlas mesh) vs Synty Sidekicks (72 ARKit blendshapes on head, modular mesh, full expression range). Synty Sidekicks selected for all characters. Key findings: Sidekick facial animation clips target `path:mesh` -- requires "Combine Character Meshes" toggle when exporting from Sidekick editor. Combined mesh = single SMR with 84 blendshapes, works with AC_FacialAnim.controller out of the box. Uncombined = 22 modular SMRs, needs custom blendshape dispatcher (future work for P&C). Decision: **combined mesh for VN games** (fixed appearances), **uncombined modular mesh for P&C** (runtime outfit swapping). Installed Synty Store Importer (cloned locally, UPM git URLs broken on this machine). Installed Synty animation packs: Idles, Emotes, Taunts, Basic Locomotion. BodyPoser asset added for manual bone posing in editor -- works on humanoid rigs but requires Animator Controller removed (conflicts with bone control). PolyPerfect _M vs _T folders: _M = multiple flat-color materials (easier color tweaking), _T = single atlas texture (better perf). SFX audio sourced: 27 .wav files at `Assets/_VNPC/Games/GITT/Audio/SFX/` covering all 34 SFX placements across 16 scenes. One remaining: FranticClacking (will pitch-shift Clacking). Next: GITT Phase 5 (Audio integration -- wire SFX commands + source music tracks).

**Session 9 (Apr 4-5, 2026):** GRIMMORPG switched from 2D to 2.5D perspective. Deleted old 2D AC setup and re-ran New Game Wizard with 2.5D template (Point And Click, Choose Interaction Then Hotspot, Mouse And Keyboard, Unity Navigation). Nine Verbs not available in 2.5D wizard -- using Choose Interaction Then Hotspot instead (same underlying mechanic, verb UI customizable later). BeatriceRoom scene content (Room: 7 wall/floor/ceiling pieces, Furniture: 29 props, SyntyWomanComboMesh character) migrated into new GRIMMORPG AC scene via Roslyn script (cross-scene MoveGameObjectToScene). Room and Furniture placed under `_SetGeometry`, character under `_NPCs`. Synty combined mesh character swapped into AC SamplePlayer3D prefab: copied entire SyntyWomanComboMesh as child (preserves SkinnedMeshRenderer bone references -- copying mesh/root separately breaks bone bindings), removed default AC mesh/skeleton, configured CharacterController (height 1.7, radius 0.3). Created BeatriceAC.controller (`Assets/_VNPC/Games/GRIMMORPG/Animation/`) with AC-expected parameters (Speed, IsTalking, Jump, IsGrounded) + Synty expression params + Idle/Walk states (no clips yet). GameCamera25D created and positioned (0, 2.5, -5.5) with 15-degree downward tilt, wired as PlayerStart's cameraOnStart. NavMesh baked on floor with furniture as obstacles (14 triangles). Player spawns and renders correctly. Click-to-move not yet verified. Rationale for 2.5D: leverages existing 3D asset library directly instead of render-to-PNG pipeline, fixed camera angles suit P&C genre (Grim Fandango approach), AC supports it natively.

**Session 10 (Apr 5, 2026):** GRIMMORPG split from VNPC into standalone project at `E:\Unity\GRIMMORPG`. Adventure Creator dropped after practical evaluation (2 sessions of setup, player couldn't walk, every feature had better standalone alternative). Modular stack adopted (Dialogue System + Ink + Animancer Pro + Easy Save 3 + Inventory Framework 2 + Text Animator + Cinemachine + custom). All GRIMMORPG assets, scenes, managers, and GDD removed from VNPC project (BeatriceRoom scene kept as reference). VNPC project now focused exclusively on visual novels (GITT, EF). Status doc updated: scope narrowed, game lineup split, repo field updated. GitHub repo created (TecVooDoo/VNPC), .gitignore configured, initial commit pushed.

---

## Milestone Progress

| Milestone | Phase | Status | Notes |
|-----------|-------|--------|-------|
| Foundation validated | 0 | **Complete** | All 18 syntax tests pass. Config fixes: uncheck Disable Rendering (Camera), uncheck Disable Input + check Spawn Event System (Input), set Active Input Handling to Both (Player Settings) |
| Text Animator integrated | 1 | **Complete** | TATextPrinterPanel + TADialogue prefab. All TA effects work (wave, shake, bounce, wiggle). Tags survive Naninovel parser. Prefab at Resources/Naninovel/TextPrinters/TADialogue |
| Characters registered | 2 | **Complete** | 4 characters (20 total appearances), 4 backgrounds. Phase2Test validated |
| Greybox prototype | 3 | **Complete** | 16 scenes + entry script. Full story playable start-to-finish with placeholders |
| TA polish complete | 4 | **Complete** | shake/wave/bounce/wiggle across all 16 scenes. Playtested, no errors. |
| Audio integrated | 5 | Pending | All music and SFX in place |
| Art integrated | 6 | Pending | No placeholders remain |
| Ship-ready | 7 | Pending | Tested, polished, built |

---

## Known Issues

| Issue | Severity | Status | Notes |
|-------|----------|--------|-------|
| TitleUI resource not found | Low | Deferred | Title.nani @showUI TitleUI fails -- need to register TitleUI or write custom title script. Not blocking development. |
| Mouse click doesn't advance dialogue | Low | Known | Naninovel maps Continue to scroll wheel, not left-click. Enter key and scroll work. Can customize in DefaultControls.inputactions (Phase 7 polish). |

---

## Session Close Checklist

- [ ] Update session summary (1-2 lines)
- [ ] Update milestone progress if changed
- [ ] Update known issues if changed
- [ ] Update `VNPC_CodeReference.md` if APIs changed
- [ ] Update `VNPC_DevReference.md` if architecture/scripts changed

---

**End of Project Status**
