﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mugen;
using XNode;

[CreateNodeMenu("AI/按键设置")]
public class AI_KeyCmd : Node {
	public string name = "KeyCmd_Unknown";
	public float time = 1;
	public string keyCommands;

	[Output(ShowBackingValue.Never)]
	public AI_KeyCmd output;
	public override object GetValue(NodePort port) {
		return output;
	}
}


[CreateNodeMenu("AI/AI命令")]
public class AI_Cmd : Node
{
	
	public string cmdName = "AICmd_Unknown";

	public AI_Type aiType = AI_Type.ChangeState;

	public string value;

	[Input(ShowBackingValue.Never)]
	public List<AI_BaseCondition> condList;

	[Output(ShowBackingValue.Never)]
	public AI_Cmd output;

	public override object GetValue(NodePort port) {
		if (port.fieldName == "condList")
			return condList;
		else if (port.fieldName == "output")
			return output;
		return null;
	}
}

public abstract class AI_BaseCondition : Node
{
	[Output]
	public AI_BaseCondition output;
	public override object GetValue(NodePort port) {
		return this;
	}
}

[CreateNodeMenu("AI/条件/And")]
public class AI_Cond_And: AI_BaseCondition
{
	[Input(ShowBackingValue.Never)]
	public List<AI_BaseCondition> inputs;
	public override object GetValue(NodePort port) {
		return inputs;
	}
}

[CreateNodeMenu("AI/条件/Or")]
public class AI_Cond_Or: AI_BaseCondition
{
	[Input(ShowBackingValue.Never)]
	public List<AI_BaseCondition> inputs;
	public override object GetValue(NodePort port) {
		return inputs;
	}
}

[CreateNodeMenu("AI/条件/触发按键")]
public class AI_Cond_TriggleKeyCmd: AI_BaseCondition
{
	[Input(ShowBackingValue.Never)]
	public AI_KeyCmd aiKeyCmd;
	public override object GetValue(NodePort port) {
		if (port.fieldName == "aiKeyCmd")
			return aiKeyCmd;
		return null;
	}

	public bool isNot = false;
}

[CreateNodeMenu("AI/条件/角色StateType状态")]
public class AI_Cond_PlayerStateType: AI_BaseCondition
{
	public Cns_Type stateType = Cns_Type.S;

	public bool isNot = false;	
}

[CreateNodeMenu("AI/条件/角色Ctrl状态")]
public class AI_Cond_PlayerCtrl: AI_BaseCondition
{
	public int Ctrl = 1;
	public bool isNot = false;	
}

public enum AI_Cond_Op
{
	Less,
	LessOrEqual,
	Great,
	GreatAndEqual,
	Equal
}

[CreateNodeMenu("AI/条件/角色AnimElem")]
public class AI_Cond_PlayerAniElem: AI_BaseCondition
{
	public int aniElem;
	public AI_Cond_Op op = AI_Cond_Op.Equal;
}

[CreateNodeMenu("AI/条件/角色AnimTime")]
public class AI_Cond_PlayerAniTime: AI_BaseCondition
{
	public int aniTime;
	public AI_Cond_Op op = AI_Cond_Op.Equal;
}

[CreateNodeMenu("AI/条件/角色Time")]
public class AI_Cond_PlayerTime: AI_BaseCondition
{
	public int time;
	public AI_Cond_Op op = AI_Cond_Op.Equal;
}

[CreateNodeMenu("AI/条件/角色 VelX")]
public class AI_Cond_Player_VelX: AI_BaseCondition
{
	public float velX;
	public AI_Cond_Op op = AI_Cond_Op.Equal;
}

[CreateNodeMenu("AI/条件/角色 VelY")]
public class AI_Cond_Player_VelY: AI_BaseCondition
{
	public float velY;
	public AI_Cond_Op op = AI_Cond_Op.Equal;
}

[CreateNodeMenu("AI/条件/角色 PosX")]
public class AI_Cond_Player_PosX: AI_BaseCondition
{
	public float posX;
	public AI_Cond_Op op = AI_Cond_Op.Equal;
}

[CreateNodeMenu("AI/条件/角色 PosY")]
public class AI_Cond_Player_PosY: AI_BaseCondition
{
	public float posY;
	public AI_Cond_Op op = AI_Cond_Op.Equal;
}

[CreateNodeMenu("AI/条件/角色StateNo")]
public class AI_Cond_Player_StateNo: AI_BaseCondition
{
	public int stateNo;
	public AI_Cond_Op op = AI_Cond_Op.Equal;
}

[CreateNodeMenu("AI/条件/float var")]
public class AI_Cond_Player_FloatVar: AI_BaseCondition
{
	public int index;
	public AI_Cond_Op op = AI_Cond_Op.Equal;
}

[CreateNodeMenu("AI/条件/int var")]
public class AI_Cond_Player_IntVar: AI_BaseCondition
{
	public int index;
	public AI_Cond_Op op = AI_Cond_Op.Equal;
}

[CreateNodeMenu("AI/条件/角色PrevStateNo")]
public class AI_Cond_Player_PlayerPrevStateNo: AI_BaseCondition
{
	public int prevStateNo;
	public AI_Cond_Op op = AI_Cond_Op.Equal;
}

[CreateNodeMenu("AI/条件/角色状态Persistent")]
public class AI_Cond_PlayerState_Persistent: AI_BaseCondition
{
	public bool isNot = false;
}

[CreateNodeMenu("AI/条件/角色Power值")]
public class AI_Cond_PlayerPower: AI_BaseCondition
{
	public int value;
	public AI_Cond_Op op = AI_Cond_Op.Equal;
}

[CreateNodeMenu("AI/条件/角色Life值")]
public class AI_Cond_PlayerLife: AI_BaseCondition
{
	public int value;
	public AI_Cond_Op op = AI_Cond_Op.Equal;
}

[CreateNodeMenu("AI/条件/角色HitCount值")]
public class AI_Cond_PlayerHitCount: AI_BaseCondition
{
	public int value;
	public AI_Cond_Op op = AI_Cond_Op.Equal;
}

[CreateNodeMenu("AI/条件/角色动画Ani是否存在")]
public class AI_Cond_PlayerAniExist: AI_BaseCondition
{
	public int value;
	public bool isNot = false;
}

[CreateNodeMenu("AI/条件/角色是否Alive")]
public class AI_Cond_PlayerIsAlive: AI_BaseCondition
{
	public bool isNot = false;
}

[CreateNodeMenu("AI/条件/角色AnimElemTime")]
public class AI_Cond_PlayerAnimElemTime: AI_BaseCondition
{
	public int animElem;
	public AI_Cond_Op op = AI_Cond_Op.Equal;
}



[CreateNodeMenu("AI/创建StateDef")]
public class AI_CreateStateDef: Node
{
	[Input(ShowBackingValue.Never)]
	public AI_Cmd input;
	[Input(ShowBackingValue.Never)]
	public AI_StateEvent_PlayCns prevCns;
	[Output(ShowBackingValue.Never)]
	public AI_CreateStateDef output;

	public Cns_Type type = Cns_Type.S;
	public Cns_MoveType moveType = Cns_MoveType.none;
	public Cns_PhysicsType physicsType = Cns_PhysicsType.S;
	public int juggle = 0;
	public int powerAdd = 0;
	public float velset_x = CNSStateDef._cNoVaildVelset;
	public float velset_y = CNSStateDef._cNoVaildVelset;
	//public int animate = 0;
	public int ctrl = 0;
	public int sprpriority = 0;

	public override object GetValue(NodePort port)
	{
		if (port.fieldName == "input")
			return input;
		else if (port.fieldName == "output")
			return output;
		else if (port.fieldName == "prevCns")
			return prevCns;
		return null;
	}

	public override void OnCreateConnection(NodePort from, NodePort to) { 
		if (from != null && from.node.GetType() == typeof(AI_Cmd)) {
			AI_Cmd aiCmd = (AI_Cmd)from.node;
			if (aiCmd.aiType != AI_Type.ChangeState) {
				var port = GetInputPort("input");
				if (port != null)
					port.ClearConnections ();
			}
		}
	}
}

//[CreateNodeMenu("AI/创建StateEvent")]
public abstract class AI_CreateStateEvent: Node
{
	[Input(ShowBackingValue.Never)]
	public AI_CreateStateDef parent;

	[Input(ShowBackingValue.Never)]
	public AI_BaseCondition conditions;

	public bool setPersistent = false;

	public CnsStateTriggerType triggleType = CnsStateTriggerType.AnimElem;

	public override void OnCreateConnection(NodePort from, NodePort to)
	{
		if (from != null && (from.node.GetType() == typeof(AI_Cond_PlayerTime) ||
			from.node.GetType() == typeof(AI_Cond_PlayerAniTime))) {
			triggleType = CnsStateTriggerType.AnimTime;
		} else if ((from != null) && (from.node.GetType() == typeof(AI_Cond_PlayerAniElem)) ||
			(from.node.GetType() == typeof(AI_Cond_PlayerAnimElemTime))) {
			triggleType = CnsStateTriggerType.AnimElem;
		}
	}

	public override object GetValue(NodePort port)
	{
		if (port.fieldName == "parent")
			return parent;
		else if (port.fieldName == "conditions")
			return conditions;
		return null;
	}
}

[CreateNodeMenu("AI/创建StateEvent/播放声音")]
public class AI_StateEvent_PlaySnd: AI_CreateStateEvent
{
	public int group;
	public int index;
}

[CreateNodeMenu("AI/创建StateEvent/设置速度")]
public class AI_StateEvent_VelSet: AI_CreateStateEvent
{
	public float velx = CNSStateDef._cNoVaildVelset;
	public float vely = CNSStateDef._cNoVaildVelset;
}

[CreateNodeMenu("AI/创建StateEvent/速度增加")]
public class AI_StateEvent_VelAdd: AI_CreateStateEvent
{
	public float velx = CNSStateDef._cNoVaildVelset;
	public float vely = CNSStateDef._cNoVaildVelset;
}

[CreateNodeMenu("AI/创建StateEvent/位置增加")]
public class AI_StateEvent_PosAdd: AI_CreateStateEvent
{
	public int x = CNSStateDef._cNoVaildVelset;
	public int y = CNSStateDef._cNoVaildVelset;
}

[CreateNodeMenu("AI/创建StateEvent/设置位置")]
public class AI_StateEvent_PosSet: AI_CreateStateEvent
{
	public int x = CNSStateDef._cNoVaildVelset;
	public int y = CNSStateDef._cNoVaildVelset;
}

[CreateNodeMenu("AI/创建StateEvent/StateType设置")]
public class AI_StateEvent_StateTypeSet: AI_CreateStateEvent
{
	public Cns_Type stateType = Cns_Type.S;
}

[CreateNodeMenu("AI/创建StateEvent/Ctrl设置")]
public class AI_StateEvent_CtrlSet: AI_CreateStateEvent
{
	public int ctrl = 1;
}

[CreateNodeMenu("AI/创建StateEvent/创建爆炸")]
public class AI_StateEvent_CreateExplod: AI_CreateStateEvent
{
	public int anim = CNSStateDef._cNoVaildAnim;
	public int id = 0;
	public int pos_x = 0;
	public int pos_y = 0;
	public ExplodPosType explodPosType = ExplodPosType.p1;
	public int bindtime = 0;
	public int removetime = -2;
	public int sprpriority = 0;
	public int removeongethit = 0;
	public int ignorehitpause = 1;
	public bool isChangeStateRemove = true;
	public bool IsUseParentUpdate = true;
}

[CreateNodeMenu("AI/创建StateEvent/播放动画")]
public class AI_StateEvent_PlayAni: AI_CreateStateEvent
{
	public int anim = CNSStateDef._cNoVaildAnim;
	public bool isLoop = false;
	public bool isCleanStateDef = true;
}

[CreateNodeMenu("AI/创建StateEvent/切换Cns状态")]
public class AI_StateEvent_PlayCns: AI_CreateStateEvent
{
	[Output(ShowBackingValue.Never)]
	public AI_CreateStateDef nextStateDef;

	public string Animate;

	public override object GetValue(NodePort port)
	{
		if (port.fieldName == "nextStateDef")
			return nextStateDef;
		return null;
	}
}

[CreateNodeMenu("AI/创建StateEvent/切换Stand状态")]
public class AI_StateEvent_PlayStandCns: AI_CreateStateEvent
{}

[CreateNodeMenu("AI/创建StateEvent/创建飞行物")]
public class AI_StateEvent_CreateProj: AI_CreateStateEvent
{
	public int projid = -1;
	public int projanim = CNSStateDef._cNoVaildAnim;
	public int projhitanim = CNSStateDef._cNoVaildAnim;
	public int projremove = 1;
	public int projcancelanim = CNSStateDef._cNoVaildAnim;
	public int projremanim = CNSStateDef._cNoVaildAnim;
	public float projremovetime = -1;
	public int offset_x = 0;
	public int offset_y = 0;
	public float velocity_x = 0;
	public float velocity_y = 0;
	public ExplodPosType Postype = ExplodPosType.p1;
	public int projshadow = 0;
	public int projpriority = 0;
	public int projsprpriority = 0;

}

[CreateNodeMenu("AI/创建StateEvent/删除爆炸物")]
public class AI_StateEvent_RemoveExplod: AI_CreateStateEvent
{
	public int id;
}

[CreateNodeMenu("AI/创建StateEvent/切换调色板")]
public class AI_StateEvent_ChangePallet: AI_CreateStateEvent
{
	public int index;
}

[CreateNodeMenu("AI/创建StateEvent/设置float var")]
public class AI_StateEvent_floatVarSet: AI_CreateStateEvent
{
	public int index;
	public float value;
}

[CreateNodeMenu("AI/创建StateEvent/设置int var")]
public class AI_StateEvent_intVarSet: AI_CreateStateEvent
{
	public int index;
	public int value;
}

[CreateNodeMenu("AI/创建StateEvent/角色暂停")]
public class AI_StateEvent_PlayerPause: AI_CreateStateEvent
{
	public float time;
}

[CreateNodeMenu("AI/创建StateEvent/速度乘法")]
public class AI_StateEvent_VelMul: AI_CreateStateEvent
{
	public float velX = CNSStateDef._cNoVaildVelset;
	public float velY = CNSStateDef._cNoVaildVelset;
}

[CreateNodeMenu("AI/创建StateEvent/删除角色自己")]
public class AI_StateEvent_PlayerDestroySelf: AI_CreateStateEvent
{}