# Changelog

## <u>v1.0.7.0</u>

### Added
- Code related to the guide like get the map where the guide is.

### Changed
- HPointInfo code move to KKS causing problems in KK

### Fixed
- Correctly determine where the guide is.

## <u>v1.0.6.2 0 2020-11-03</u>

### Fixed

- Correctly determine the map number the Guide is in.

## <u>v1.0.6.0 - 2022-11-03</u>

### Added
- Configuration settings to control debug log messages

Extensions:
- SaveData.Heroine MapNumber() get map number where the heroine is
- Vector2, Vector3, Quaternion Format() print formatting to help debugging
 
### Changed

- Refactoring of HProcMonitor events OnStartLoading, OnFinishLoading and OnEnd. Added
OnInit.  OnStartLoading now occurs before HSceneProc.Start.

### Fixed

- Log incompatibility with older plug-ins

## <u>v1.0.1.1 - 2022-11-03</u>

First Release
