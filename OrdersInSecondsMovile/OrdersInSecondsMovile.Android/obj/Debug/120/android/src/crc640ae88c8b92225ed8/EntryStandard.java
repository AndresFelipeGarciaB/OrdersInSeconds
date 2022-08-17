package crc640ae88c8b92225ed8;


public class EntryStandard
	extends crc643f46942d9dd1fff9.EntryRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("OrdersInSecondsMovile.Droid.Renderers.EntryStandard, OrdersInSecondsMovile.Android", EntryStandard.class, __md_methods);
	}


	public EntryStandard (android.content.Context p0)
	{
		super (p0);
		if (getClass () == EntryStandard.class)
			mono.android.TypeManager.Activate ("OrdersInSecondsMovile.Droid.Renderers.EntryStandard, OrdersInSecondsMovile.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public EntryStandard (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == EntryStandard.class)
			mono.android.TypeManager.Activate ("OrdersInSecondsMovile.Droid.Renderers.EntryStandard, OrdersInSecondsMovile.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public EntryStandard (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == EntryStandard.class)
			mono.android.TypeManager.Activate ("OrdersInSecondsMovile.Droid.Renderers.EntryStandard, OrdersInSecondsMovile.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
