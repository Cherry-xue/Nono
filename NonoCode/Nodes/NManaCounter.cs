using Godot;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization;
using MegaCrit.Sts2.Core.Nodes.HoverTips;
using System;

namespace MoeNegiMod.Nono.Nodes;

public partial class NManaCounter : Control
{
	private HoverTip _hoverTip;

	public override void _Ready()
	{
		_hoverTip = new HoverTip(new LocString("static_hover_tips","MANA_COUNTER.title"),new LocString("static_hover_tips", "MANA_COUNTER.description"));
		Connect(Control.SignalName.MouseEntered, Callable.From(OnHovered));
		Connect(Control.SignalName.MouseExited, Callable.From(OnUnhovered));
	}
	private void OnHovered()
	{
		NHoverTipSet nHoverTipSet = NHoverTipSet.CreateAndShow(this, _hoverTip);
		nHoverTipSet.GlobalPosition = GlobalPosition + new Vector2(-70f, -150f);
	}

	private void OnUnhovered()
	{
		NHoverTipSet.Remove(this);
	}
	public override void _Process(double delta)
	{

	}
}
