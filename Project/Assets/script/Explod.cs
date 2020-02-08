﻿using UnityEngine;
using System.Collections;
using LuaInterface;
using Mugen;

public enum ExplodPosType
{
	p1,
	p2,
	back,
	left,
	right
}

[RequireComponent(typeof(PlayerDisplay))]
public class Explod : PlayerPart {
	private PlayerDisplay m_Display = null;
	private bool m_IsDestroy = false;

	protected PlayerDisplay Display {
		get {
			if (m_Display == null)
				m_Display = GetComponent<PlayerDisplay> ();
			return m_Display;
		}
	}

	public int anim = (int)PlayerState.psNone;
	public int ID = -1;
	public int removetime = -2;
	public float bindtime = -1; // 单位：秒
	public int pos_x = 0;
	public int pos_y = 0;
	public ExplodPosType postype = ExplodPosType.p1;
	public float x_vel;
	public float y_vel;
	public int sprpriority = 0;
	public int removeongethit = 0;
	public int ignorehitpause = 1;

	protected bool IsUseParentUpdate
	{
		get {
			return ignorehitpause == 1;
		}
	}

	void UpdateOffsetPos(PlayerDisplay parentDisplay)
	{
		if (m_IsDestroy || parentDisplay == null)
			return;
		
		if (postype == ExplodPosType.p1) {
			var display = this.Display;
			if (display != null) 
			{
				Vector2 offset = -parentDisplay.transform.localPosition + parentDisplay.m_OffsetPos;
				Vector2 vv = (new Vector2 (((float)pos_x) / PlayerDisplay._cPerUnit, ((float)pos_y)) / PlayerDisplay._cPerUnit) + offset;
				display.m_OffsetPos = vv;
				display.m_OffsetPos.z = parentDisplay.IsFlipX ? 1: -1;
			}
		}
	}



	public void Apply()
	{
		if (m_IsDestroy)
			return;
		
		var display = this.Display;
		if (display != null) {
			var parentDisplay = GetParentDisplay ();
			UpdateOffsetPos (parentDisplay);
			display.SetVelSet (x_vel, y_vel);
			if (!IsUseParentUpdate) {
				bool isLoop = removetime == -1;
				ApplyParentDisplayLoaderPlayer (parentDisplay);
				display.PlayAni (anim, isLoop);
			}
		}
	}

	[NoToLua]
	internal override void OnParentUpdateFrame(ImageAnimation target)
	{
		if (m_IsDestroy)
			return;


		if (IsUseParentUpdate) {
			this.InternalParentUpdateFrame (target, (PlayerState)anim);
		}
	}

	void InteralDoDestroy()
	{
		if (m_IsDestroy)
			return;
		m_IsDestroy = true;
		InteralDestroy ();
		GameObject.Destroy (this.gameObject);
	}

	[NoToLua]
	internal override void OnParentFrameEnd(ImageAnimation target)
	{
		if (IsUseParentUpdate) {
			if (removetime == -2) {
				InteralDoDestroy ();
			}
		}
	}

	[NoToLua]
	internal override void OnParentFramePosUpdate(ImageAnimation target)
	{
		if (m_IsDestroy)
			return;
		UpdateOffsetPos (target.CacheDisplayer);
	}

	void OnImageAnimationFrame()
	{
		if (!IsUseParentUpdate) {
			var display = this.Display;
			if (display != null) {
				if (display.Trigger_AnimTime () == 0) {
					// 最后一帧
					if (removetime == -2) {
						InteralDoDestroy ();
					}
				}
			}
		}
	}

	void UpdateBindTime()
	{
		if (bindtime > 0) {
			bindtime -= AppConfig.GetInstance ().DeltaTime;
			if (bindtime <= 0) {
				bindtime = -1;
				InteralDoDestroy ();
			}
		}
	}

	void UpdateRemoveTime()
	{
		if (removetime > 0) {
			--removetime;
			if (removetime <= 0) {
				InteralDoDestroy ();
			}
		}
	}

	void LateUpdate()
	{
		if (!AppConfig.GetInstance ().IsUsePhysixUpdate) {
			UpdateBindTime ();
			UpdateRemoveTime ();
		}
	}

	void FixedUpdate()
	{
		if (AppConfig.GetInstance ().IsUsePhysixUpdate) {
			UpdateBindTime ();
			UpdateRemoveTime ();
		}
	}

}
