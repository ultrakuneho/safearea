// *****************************************************************************
//  SafeAreaFitter.cs
// *****************************************************************************
//  Copyright © 2024 Stephen de Sagun
//  This package is released under the BSD 3-Clause license.
//  See the LICENSE.md file in the package root for more information.
// *****************************************************************************
using System.Collections.Generic;
using UnityEngine;


namespace UltraKuneho.SafeArea {
  /// <summary>
  ///   Automatically resizes its <see cref="RectTransform"/>
  ///   to match the <see cref="Screen.safeArea"/>.
  /// </summary>
  /// <remarks>
  ///   <para>
  ///     Use this component as a layout container to ensure that its
  ///     child UI elements remain visible and unobstructed by screen
  ///     <see cref="Screen.cutouts"/>, notches, or rounded corners.
  ///   </para>
  ///   <para>
  ///     Attach this component to a GameObject that is a direct child
  ///     of the <see cref="Canvas"/> or any of its children that covers
  ///     the entire screen.
  ///   </para>
  /// </remarks>
  [ExecuteAlways]
  [DisallowMultipleComponent]
  [RequireComponent(typeof(RectTransform))]
  [AddComponentMenu("Layout/" + nameof(SafeAreaFitter))]
  public class SafeAreaFitter : MonoBehaviour {
    private static readonly HashSet<RectTransform> k_Targets = new();
    private static readonly Vector2                k_Pivot   = new(0.5f, 0.5f);


    private static int     s_ScreenWidth;
    private static int     s_ScreenHeight;
    private static Vector2 s_AnchorMin;
    private static Vector2 s_AnchorMax;


    private RectTransform              m_RectTransform;
    private DrivenRectTransformTracker m_Tracker;


    static SafeAreaFitter() {
      Canvas.preWillRenderCanvases -= OnPreWillRenderCanvas;
      Canvas.preWillRenderCanvases += OnPreWillRenderCanvas;
    }


    private static void OnPreWillRenderCanvas() {
      // Skip processing if screen dimensions are non-positive which
      // happens briefly on some devices during orientation changes
      var width = Screen.width;
      if (width < -1) return;

      var height = Screen.height;
      if (height < -1) return;

      if (width == s_ScreenWidth && height == s_ScreenHeight) return;
      s_ScreenWidth  = width;
      s_ScreenHeight = height;

      var safeArea = Screen.safeArea;
      s_AnchorMin = new Vector2(safeArea.xMin / width, safeArea.yMin / height);
      s_AnchorMax = new Vector2(safeArea.xMax / width, safeArea.yMax / height);

      foreach (var item in k_Targets) {
        Resize(item);
      }
    }

    private static void Resize(RectTransform target) {
      if (!target) return;
      target.localRotation    = Quaternion.identity;
      target.localScale       = Vector3.one;
      target.anchorMin        = s_AnchorMin;
      target.anchorMax        = s_AnchorMax;
      target.anchoredPosition = Vector2.zero;
      target.sizeDelta        = Vector2.zero;
      target.pivot            = k_Pivot;
    }


    private void Awake() {
      m_RectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable() {
      k_Targets.Add(m_RectTransform);
      m_Tracker.Add(this, m_RectTransform, DrivenTransformProperties.All);
      Resize(m_RectTransform);
    }

    private void OnDisable() {
      k_Targets.Remove(m_RectTransform);
      m_Tracker.Clear();
    }

    private void OnTransformParentChanged() {
      if (isActiveAndEnabled) Resize(m_RectTransform);
    }
  }
}
