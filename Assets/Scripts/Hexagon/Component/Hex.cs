using Hexagon.Data;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexagon.Component {
    public class Hex : SerializedMonoBehaviour {
        [OdinSerialize] private HexData data;
        public List<Player> players;
        public Industry industry;
        public SpriteRenderer industryIcon;
        public Camera _camera;
        public VectorHexagonal HexagonalPosition { get => data.hexagonalPosition; set => data.hexagonalPosition = value; }

        private void Awake() {
            Init();
        }
        public void Init() {
            data = new HexData();
            players = new List<Player>();
        }

        public void InitWithIndustry(Industry industry) {
            this.industry = industry;
            industryIcon.sprite = industry.sprite;
            _camera = Camera.main;
            RotateToCamera();
        }
        
        private void RotateToCamera() {
            var direction = new Vector3(industryIcon.transform.position.x, 0, industryIcon.transform.position.z) - new Vector3(Camera.main.transform.position.x, 0, Camera.main.transform.position.z);
            float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
            industryIcon.transform.localRotation = Quaternion.Euler(0, 0, angle - 90);
        }
    }
}