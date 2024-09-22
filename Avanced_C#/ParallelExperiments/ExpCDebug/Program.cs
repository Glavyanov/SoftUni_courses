using System.Runtime.CompilerServices;

Parallel.For(0, 10, i => A());

[MethodImpl(MethodImplOptions.NoInlining)]
static void A() => B();

[MethodImpl(MethodImplOptions.NoInlining)]
static void B() => C();

[MethodImpl(MethodImplOptions.NoInlining)]
static void C() => Thread.Sleep(1_000_000);