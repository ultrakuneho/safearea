SafeArea
========

This package provides the `SafeAreaFitter` component, a layout container that
dynamically adjusts its size and position to match the screen's safe area to
ensure key UI components remain visible and unobstructed by screen cutouts,
notches, or rounded corners.


## Table of Contents
- [Features](#features)
- [Compatibility](#compatibility)
- [Installation](#installation)
  - [Latest Stable Version](#latest-stable-version)
  - [Specific Version](#specific-version)
- [Usage](#usage)
- [Examples](#examples)
- [Changelog](#changelog)
- [License](#license)
- [Support](#support)
- [Authors](#authors)


## Features
 
- **Real-Time Preview**: \
  Supports real-time previews of layout and orientation changes in the `Scene`,
  `Game`, and `Device Simulator` views during `Edit Mode`.

- **Simple and Efficient**: \
  Uses a centralized static approach to perform calculations only when changes
  occur, applying cached values to instances to avoid redundant computations and
  unnecessary transformations per frame.

- **Supports Transform Parent Changes**: \
  Detects changes in the parent hierarchy, essential when the destination
 `Canvas`'s scale differs from the source.

## Compatibility

-   **Min Unity Version** : 2021.1.0f1
-   **UI System**         : Unity UI (_uGUI_)
    > *Note: This package is not compatible with UI Toolkit*

## Installation

### Latest Stable Version

1. Open your Unity project.
2. Go to `Window` › `Package Manager`.
3. Click on the `+▾` button › `Add package from git URL…`.
4. Enter the following Git URL to add the latest version:
   ```
   https://github.com/ultrakuneho/safearea.git#main
   ```
5. Click `Add` to install.


### Specific Version

1. Follow steps 1 to 3 of the
   [Latest Stable Version](#latest-stable-version)
   section.
2. Enter the following Git URL, replacing `v1.0.0` with the desired version tag:
   ```
   https://github.com/ultrakuneho/safearea.git#v1.0.0
   ```
3. Click `Add` to install.

## Usage

1.**Create a Layout Container**:
  - Pick or create an empty `GameObject` that will serve as a layout container
    for UI elements that you want to remain inside the safe area.
  - Ensure this `GameObject` is a direct child of the `Canvas` or any of its
    children covering the entire screen.
2.**Attach the `SafeAreaFitter`**:
  - **Via the Inspector**:
    - Select the GameObject.
    - Click `Add Component` in the Inspector window.
    - Search for `SafeAreaFitter` and click to add it.
  - **Dragging and Dropping**:
    - In the `Project` window, navigate to `Packages/SafeArea/Runtime`.
    - Drag and drop the `SafeAreaFitter` script onto the GameObject.

## Examples

The package includes a sample scene demonstrating the basic usage of
`SafeAreaFitter`.

To import the basic example using the Unity Package Manager:

1. Open your Unity project.
2. Go to `Window` › `Package Manager`.
3. In the Package Manager, select the `SafeArea` package.
4. Expand the `Samples` section at the bottom of the Package Manager window.
5. Click on the `Import` button next to "Demo".

## Changelog

For a detailed list of changes, refer to [CHANGELOG.md](CHANGELOG.md).

## License

This project is licensed under the BSD 3-Clause License.
See [LICENSE.md](LICENSE.md) for details.

## Support

For any questions or issues, please open an
[issue](https://github.com/ultrakuneho/safearea/issues).

## Authors

- **Stephen de Sagun** - [GitHub](https://github.com/ultrakuneho)
