using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [HideInInspector]
    public Transform PlayerTransform;
    private float m_fBeginLine;// check the ball whether enter the next line. 
    public float Cell_Z = 3;//CellZ is the basic unit
    public float WindowForwardOffset = 10f;//the Bottom of the Window.
    public float WindowBackOffset = -10f;//the Top of the Window.
    public int CubeCellCount = 10;//The distance between two barrages = CubeCellCount * CellZ.
    public int TubeCellCount = 4;//The distance between two barrages = TubeCellCount * CellZ.
    public float CoinProbability = 0.1f;//The probability of the coin to generated.
    public float BeginDistance = 30;//The begin distance of the spawner to generate the barrage.
    //public Color CubeColor;// The Color of the Barrage.
    public List<Color> CubeColors = new List<Color>();
    private int m_CubeRemainCellCount;// remain cell count
    private int m_TubeRemainCellCount;// remain tube count
    private int m_CurrentLine = 0;// current line of ball
    private int m_PreLine = 0;// previous line of ball
    private float m_TubePosition_Z = 20;// the tube position
    private List<float> m_BarrageZPosList = new List<float>();// the position of each barrage
    public List<float> BarrageZposList
    {
        get
        {
            return m_BarrageZPosList;
        }
    }
    private static Spawner instance;
    public static Spawner Instance
    {
        get
        {
            return instance;
        }
    }

    public float Forward
    {
        get
        {
            return transform.position.z + WindowForwardOffset;
        }
    }

    public float Back
    {
        get
        {
            return transform.position.z + WindowBackOffset;
        }
    }
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Use this for initialization
    void Start () {
        transform.position = PlayerTransform.position;
        m_fBeginLine = transform.position.z + WindowForwardOffset;
        m_TubeRemainCellCount = TubeCellCount;
        m_TubePosition_Z = 20;
        m_CubeRemainCellCount = CubeCellCount;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (GameManager.Instacne.GameState != GameStateEnum.StartGame)
            return;
        transform.position = PlayerTransform.position;

        while (true)
        {
            if(m_PreLine != m_CurrentLine)
            {
                m_fBeginLine = m_fBeginLine + Cell_Z;
                m_PreLine = m_CurrentLine;
            }
            if (Forward < m_fBeginLine)
                return;
            m_TubeRemainCellCount--;

            if(m_TubeRemainCellCount < 0)
            {
                //create tube
                m_TubeRemainCellCount = TubeCellCount;
                Tube tube = ObjectPoolManager.instance.GetInstance("Tube").GetComponent<Tube>();
                tube.name = "Tube";
                m_TubePosition_Z += 20;
                tube.transform.position = new Vector3(0, 0, m_TubePosition_Z);
            }
            m_CubeRemainCellCount--;
            if (m_CubeRemainCellCount < 0)
            {
                //create cube
                var pos = new Vector3(0, 0, m_fBeginLine + BeginDistance);
                m_CubeRemainCellCount = CubeCellCount;
                CreateCube(pos);
                m_BarrageZPosList.Add(m_fBeginLine + BeginDistance);
            }
            else
            {
                //create coin
                var pos = new Vector3(0, 0, m_fBeginLine + BeginDistance);
                CreateCoin(pos);
            }
            m_CurrentLine++;
        }
	}

    //create cube
    void CreateCube(Vector3 position)
    {
        Rule rule = RuleManager.Instacne.GetRandomRule();
        List<int> list = rule.GetList();
        int type = (int)rule.type;
        int Dir = rule.GetDir();
        bool bRotate = rule.bRotate;
        float rotateSpeed = rule.RotateSpeed;
        int targetAngle = rule.TargetAngle;
        for (int i = 0; i < list.Count; i++)
        {
            GameObject cube = ObjectPoolManager.instance.GetInstance(rule.CubeId);
            cube.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = CubeColors[Random.Range(0, CubeColors.Count)];;
            cube.name = rule.CubeId;
            cube.transform.position = position;
            cube.transform.rotation = Quaternion.Euler(new Vector3(0, 0, list[i] * 20));
            cube.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
            CubeRotate cubeRotate = cube.GetComponent<CubeRotate>();
            cubeRotate.bRotate = bRotate;
            cubeRotate.Type = type;
            cubeRotate.Dir = Dir;
            cubeRotate.LeftAngle = rule.LeftAngle;
            cubeRotate.RightAngle = rule.RightAngle;
            cubeRotate.TargetAngle = targetAngle;
            cubeRotate.RotateSpeed = rotateSpeed;
        }
    }

    //create coin
    void CreateCoin(Vector3 position)
    {
        if (Random.Range(0f, 1f) > CoinProbability)
            return;
        int index = Random.Range(0, 6);
        GameObject coin = ObjectPoolManager.instance.GetInstance("Coin");
        coin.name = "Coin";
        coin.transform.position = position;
        coin.transform.rotation = Quaternion.Euler(new Vector3(0, 0, (index - 3) * 20));
    }
    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}
