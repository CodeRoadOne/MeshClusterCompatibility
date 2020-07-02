using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CodeRoadOne
{
    namespace MeshCluster
    {
        public class CRO_CheckCompatibility : MonoBehaviour
        {
            public Text m_ShaderModelCurrent, m_ShadeModelNeeded;
            public Text m_ComputeShaderCurrent, m_ComputeShaderNeeded;
            public Text m_InstancingCurrent, m_InstancingNeeded;
            public Text m_VertexInputsCurrent, m_VertexInputsNedded;
            public Text m_FragmentInputsCurrent, m_FragmentInputsNedded;
            public Text m_2DArrayTexturesCurrent, m_2DArrayTexturesNedded;
            public Text m_ComputeInputsCurrent, m_ComputeInputsNeeded;
            public Text m_ComputeGroupSizeXCurrent, m_ComputeGroupSizeXNeeded;
            public Text m_ComputeGroupSizeCurrent, m_ComputeGroupSizeNeeded;

            private const int cMinGraphicsShaderLevel = 45;
            private const bool cNeedsCompute = true;
            private const bool cNeedsInstancing = true;
            private const int cBestNumComputeBufferInputsCompute = 9;
            private const int cMinNumComputeBufferInputsCompute = 5;
            private const int cMinComputeBufferInputsVertex = 5;
            private const int cMinComputeBufferInputsFragment = 1;
            private const int cMinComputeWorkGroupSize = 64;

            // Start is called before the first frame update
            void Start()
            {
                m_ShadeModelNeeded.text = cMinGraphicsShaderLevel.ToString();
                m_ShaderModelCurrent.text = SystemInfo.graphicsShaderLevel.ToString();
                m_ShaderModelCurrent.color = SystemInfo.graphicsShaderLevel >= cMinGraphicsShaderLevel ? Color.green : Color.red;

                m_ComputeShaderNeeded.text = cNeedsCompute ? "TRUE" : "FALSE";
                m_ComputeShaderCurrent.text = SystemInfo.supportsComputeShaders ? "TRUE" : "FALSE";
                m_ComputeShaderCurrent.color = (cNeedsCompute && SystemInfo.supportsComputeShaders) || (!cNeedsCompute) ? Color.green : Color.red;

                m_InstancingNeeded.text = cNeedsInstancing ? "TRUE" : "FALSE";
                m_InstancingCurrent.text = SystemInfo.supportsInstancing ? "TRUE" : "FALSE";
                m_InstancingCurrent.color = (cNeedsInstancing && SystemInfo.supportsInstancing) || (!cNeedsInstancing) ? Color.green : Color.red;

                m_VertexInputsNedded.text = cMinComputeBufferInputsVertex.ToString();
                m_VertexInputsCurrent.text = SystemInfo.maxComputeBufferInputsVertex.ToString();
                m_VertexInputsCurrent.color = SystemInfo.maxComputeBufferInputsVertex >= cMinComputeBufferInputsVertex ? Color.green : Color.red;

                m_FragmentInputsNedded.text = cMinComputeBufferInputsFragment.ToString();
                m_FragmentInputsCurrent.text = SystemInfo.maxComputeBufferInputsFragment.ToString();
                m_FragmentInputsCurrent.color = SystemInfo.maxComputeBufferInputsFragment >= cMinComputeBufferInputsFragment ? Color.green : Color.red;

                m_2DArrayTexturesNedded.text = "OPTIONAL";
                m_2DArrayTexturesCurrent.text = SystemInfo.supports2DArrayTextures ? "TRUE" : "FALSE";
                m_2DArrayTexturesCurrent.color = SystemInfo.supports2DArrayTextures ? Color.green : Color.yellow;

                m_ComputeInputsNeeded.text = cBestNumComputeBufferInputsCompute.ToString();
                m_ComputeInputsCurrent.text = SystemInfo.maxComputeBufferInputsCompute.ToString();
                m_ComputeInputsCurrent.color = SystemInfo.maxComputeBufferInputsCompute >= cBestNumComputeBufferInputsCompute ? Color.green : Color.red;

                m_ComputeGroupSizeXNeeded.text = cMinComputeWorkGroupSize.ToString();
                m_ComputeGroupSizeXCurrent.text = SystemInfo.maxComputeWorkGroupSizeX.ToString();
                m_ComputeGroupSizeXCurrent.color = SystemInfo.maxComputeWorkGroupSizeX >= cMinComputeWorkGroupSize ? Color.green : Color.red;

                m_ComputeGroupSizeNeeded.text = cMinComputeWorkGroupSize.ToString();
                m_ComputeGroupSizeCurrent.text = SystemInfo.maxComputeWorkGroupSize.ToString();
                m_ComputeGroupSizeCurrent.color = SystemInfo.maxComputeWorkGroupSize >= cMinComputeWorkGroupSize ? Color.green : Color.red;
            }
        }
    }
}
