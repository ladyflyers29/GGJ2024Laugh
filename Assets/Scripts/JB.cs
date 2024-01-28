using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Debug = UnityEngine.Debug;
using UnityEngine.AI;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;
#if UNITY_EDITOR
using UnityEditor;
#endif


/*///////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////
        Helpful code bits from my game's codebase :) 
        would appreciate a shoutout @hhyperstar if you plan on using these a lot in the future
        - Hyperstar
///////////////////////////////////////////////////////////////////////////////////////////
*////////////////////////////////////////////////////////////////////////////////////////////




/////// Bitmask cheat sheet:
// set bit:     mask |= bit;
// unset bit:   mask &= ~bit;
// flip bit N:  mask ^= bit;
// mask contains bit:   (mask & bit) != 0;
// mask contains mask:  (mask & check) == check;

/*
[Serializable,Flags] public enum FlagsExample {
    None = 0,
    Val1 = 1 << 0,
    Val2 = 1 << 1,
}
*/

public static class Extensions {
    public static bool Contains(this LayerMask mask, int layer) => ((1<<layer) & mask) != 0;
    public static Vector3 VecTo(this Transform me, Vector3 goal) => goal - me.position;
    public static Vector3 VecTo(this Vector3 me, Vector3 goal) => goal - me;
    public static Diff DiffTo(this Vector3 me, Vector3 goal) => new(me, goal);
    public static float DistTo(this Transform me, Vector3 goal) => (goal - me.position).magnitude;
    public static float DistTo(this Vector3 me, Vector3 goal) => (goal - me).magnitude;
    public static void RotateAround(this Transform transform, Vector3 pivotPoint, Quaternion rot) {
        transform.position = rot * (transform.position - pivotPoint) + pivotPoint;
        transform.rotation = rot * transform.rotation;
    }
    //public static void CacheProps(this Renderer r) => r.GetPropertyBlock(JB.cachedMpb);
    //public static void ApplyProps(this Renderer r) => r.SetPropertyBlock(JB.cachedMpb);
    public static Transform FindRecursive(this Transform aParent, string aName) {
        foreach(Transform child in aParent) {
            if ( child.name == aName ) return child;
            var result = child.FindRecursive(aName);
            if (result != null) return result;
        }
        return null;
    }
    public static void AddForceAtClosestPoint(this Collider col, Vector3 fromPoint, Vector3 force, ForceMode mode = ForceMode.Impulse) {;
        if (col.attachedRigidbody == null) return;
        if (col is MeshCollider) {
            col.attachedRigidbody.AddForce( force, mode );
        }
        else {
            col.attachedRigidbody.AddForceAtPosition( force, col.ClosestPoint(fromPoint), mode );
        }
    }
    public static Vector3 BestClosestPoint(this Collider col, Vector3 fromPoint) {
        return (col is MeshCollider) ? col.ClosestPointOnBounds(fromPoint) : col.ClosestPoint(fromPoint);
    }
    public static float Round(this float f, int places) => (float)Math.Round((double)f, places);
    public static Vector3 LimitDistFrom(this Vector3 self, Vector3 from, float maxDist) {
        float dst = Vector3.Distance(from, self);
        if (dst > maxDist) {
            Vector3 vect = from - self;
            vect = vect.normalized;
            vect *= (dst-maxDist);
            return self += vect;
        }
        else return self;
    }
    public static Vector2 LimitDistFrom(this Vector2 self, Vector2 from, float maxDist) {
        float dst = Vector3.Distance(from, self);
        if (dst > maxDist) {
            Vector2 vect = from - self;
            vect = vect.normalized;
            vect *= (dst-maxDist);
            return self += vect;
        }
        else return self;
    }
    public static bool ContainsPoint(this BoxCollider box, Vector3 point ) {
		point = box.transform.InverseTransformPoint( point ) - box.center;
		
		float halfX = (box.size.x * 0.5f);
		float halfY = (box.size.y * 0.5f);
		float halfZ = (box.size.z * 0.5f);

		if( point.x < halfX && point.x > -halfX && 
		   point.y < halfY && point.y > -halfY && 
		   point.z < halfZ && point.z > -halfZ ) return true;
		else return false;
	}
    public static float MinMaxLerp(this Vector2 v, float t) => Mathf.Lerp( v.x, v.y, t );
    public static float MinMaxInvLerp(this Vector2 v, float t) => Mathf.InverseLerp( v.x, v.y, t );
    public static float RandomWithin(this Vector2 v) => Random.Range(v.x, v.y);
    public static float XTrueYFalse(this Vector2 v, bool value) => value ? v.x : v.y; 
    public static bool TryGetComponentInChildren<T>(this GameObject self, out T result) { result = self.GetComponentInChildren<T>(); return result != null; }
    public static bool TryGetComponentInChildren<T>(this Component self, out T result) { result = self.GetComponentInChildren<T>(); return result != null; }
    public static float Volume(this Bounds bounds) => bounds.size.x * bounds.size.y * bounds.size.z;
    public static float GetLargestComponent(this Vector2 self) => Mathf.Max( self.x, self.y );
    public static float GetLargestComponent(this Vector3 self) => Mathf.Max( Mathf.Max( self.x, self.y ), self.z );
    public static float GetLargestComponent(this Vector4 self) => Mathf.Max( Mathf.Max( Mathf.Max( self.x, self.y ), self.z ), self.w );
    public static float RejectionSample(this AnimationCurve curve) {
        int iterPerformed = 0;
        Vector2 range = new( curve.keys[0].time, curve.keys[curve.length-1].time );
        float randomX;
        float probability;
        do {
            iterPerformed++;
            randomX = range.RandomWithin();
            probability = curve.Evaluate( randomX );
        } while( iterPerformed < 100 && Random.value >= probability );
        #if UNITY_EDITOR
        if (iterPerformed >= 100) Debug.LogWarning(nameof(RejectionSample)+" used max possible iterations!");
        #endif
        return randomX;
    }
    public static bool Contains(this Collider col, Vector3 p) {
        #if UNITY_EDITOR
        if (col is MeshCollider mc && !mc.convex) Debug.LogWarning("I dont think this works on nonconvex colliders dawg :/");
        #endif
        return !col.Raycast( new Ray( p, p.VecTo(col.transform.position) ), out var rch, Mathf.Infinity );
    }
    public static bool TryClamp(this int self, int min, int max) {
        if (self < min) { self = min; return true; }
        if (self > max) { self = max; return true; }
        return false;
    }
    public static bool TryClamp(this float self, float min, float max) {
        if (self < min) { self = min; return true; }
        if (self > max) { self = max; return true; }
        return false;
    }
    public static bool IsComplete(this NavMeshPath p) => p.status == NavMeshPathStatus.PathComplete;
    public static bool IsUsable(this NavMeshPath p) => p.status == NavMeshPathStatus.PathComplete || p.status == NavMeshPathStatus.PathPartial;
    public static float CalcLength(this NavMeshPath p) {
        float sum = 0f;
        int count = p.GetCornersNonAlloc(cacheCorners);
        if (count < 1) return 0;
        Vector3 last = cacheCorners[0];
        for (int i = 0; i < count; i++) {
            sum += Vector3.Distance( last, cacheCorners[i] );
            last = cacheCorners[i];
        }
        return sum;
    }
    static Vector3[] cacheCorners = new Vector3[64];
    public static void DrawPath(this NavMeshPath p, Color col, float duration = 0f) {
        if (p == null) throw new ArgumentNullException(nameof(p));
        int count = p.GetCornersNonAlloc( cacheCorners );
        if (count < 1) return;
        Vector3 last = cacheCorners[0];
        for (int i = 0; i < count; i++) {
            Debug.DrawLine( last, cacheCorners[i], col, duration );
            last = cacheCorners[i];
        }
    }
    public static T RandomItem<T>(this List<T> list) {
        if (list == null || list.Count == 0) throw new System.ArgumentException("List is null or empty");
        int randomIndex = UnityEngine.Random.Range(0, list.Count);
        return list[randomIndex];
    }

    // v v v allocs for some godforsaken reason (boxing to iconvertible??). 
    // Keeping for convenience, but plz make a nongeneric version for your enum.
    public static bool Contains<T>(this T self, T checkFor) where T : IConvertible => ( (int)(IConvertible)self & (int)(IConvertible)checkFor ) != 0;
}





///<summary>
/// Efficient lil helper for when you want to know the distance and direction between two points (happens shockingly often)
/// </summary>
[Serializable] public struct Diff {
    public readonly Vector3 from;
    public readonly Vector3 to;
    public readonly Vector3 diff;
    public readonly float dist;
    public readonly Vector3 dir;
    public Vector3 clamped => Vector3.ClampMagnitude(diff, 1f);
    public Vector3 midpoint => (from + to) * 0.5f;

    public Diff( Vector3 from, Vector3 to ) {
        this.from = from;
        this.to = to;
        diff = from.VecTo(to);
        dist = diff.magnitude;
        dir = diff.normalized;
    }
}




///<summary> Weirdass timekeeping thingy that i use in literally everything
/// Call one of the Tick() methods once per frame to advance the timer. 
/// Tick() returns TRUE if the tick casued the timer to finish.
/// Call Tick(true) for looping timers. This will cause the elapsed time to reset back to 0 automatically if it finishes.
/// Tick(false) for non-looping timers. In this case you probably want to check [isDone] and maybe call [Reset()] later on to manually reset.
/// </summary>
[Serializable] public struct Timer {
    public float length;
    public float elapsed { get; private set; }
    public float ntime => elapsed / length;
    public bool isDone => ntime >= 1f;

    public Timer(float length) { this.length = length; elapsed = 0; }

    public void Reset() => elapsed = 0;
    public bool Tick(bool loop) => Tick(loop, Time.deltaTime);
    public bool TickFixed(bool loop) => Tick(loop, Time.fixedDeltaTime);
    public bool TickUnscaled(bool loop) => Tick(loop, Time.unscaledDeltaTime);
    public bool Tick(bool loop, float deltaTime) {
        elapsed += deltaTime;
        if (elapsed >= length) {
            if (loop) elapsed = 0;
            return true;
        }
        return false;
    }
    public void SetElapsed(float elapsed) => this.elapsed = elapsed;
    public void SetToDone() => this.elapsed = this.length;
}





public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver {
     
    [SerializeField] List<TKey> keys = new List<TKey>();
    [SerializeField] List<TValue> values = new List<TValue>();
    
    public void OnBeforeSerialize() {
        keys.Clear();
        values.Clear();
        foreach(KeyValuePair<TKey, TValue> pair in this) {
            keys.Add(pair.Key);
            values.Add(pair.Value);
        }
    }
    
    public void OnAfterDeserialize() {
        this.Clear();
        if (keys.Count != values.Count) throw new System.Exception(string.Format("there are {0} keys and {1} values after deserialization. Make sure that both key and value types are serializable.", keys.Count, values.Count));
        for (int i = 0; i < keys.Count; i++) {
           this.Add(keys[i], values[i]);
        }
    }

}
