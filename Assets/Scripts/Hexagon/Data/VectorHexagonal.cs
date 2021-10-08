using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexagon.Data {
    public struct VectorHexagonal {
        public VectorHexagonal(int x, int y, int z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public int x, y, z;

        public static int Distance(VectorHexagonal a, VectorHexagonal b) =>
            (Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y) + Mathf.Abs(a.z - b.z)) / 2;
        public static bool operator !=(VectorHexagonal lhs, VectorHexagonal rhs) {
            if (lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z)
                return false;
            return true;
        }
        public static bool operator ==(VectorHexagonal lhs, VectorHexagonal rhs) {
            if (lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z)
                return true;
            return false;
        }
        public static VectorHexagonal operator +(VectorHexagonal lhs, VectorHexagonal rhs) {
            return new VectorHexagonal(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }
        public static VectorHexagonal operator -(VectorHexagonal lhs, VectorHexagonal rhs) {
            return new VectorHexagonal(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }
        public static VectorHexagonal operator /(VectorHexagonal lhs, int rhs) {
            return new VectorHexagonal(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
        }
        public override bool Equals(object obj) {
            return base.Equals(obj);
        }
        public override int GetHashCode() {
            return base.GetHashCode();
        }

    }
}