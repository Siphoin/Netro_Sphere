using System;

[Serializable]
 public   class Record
    {
    public float km = 0;
    public int score = 0;

    public Record (float KM_TOTAL, int SCORE_TOTAL)
    {
        km = KM_TOTAL;
        score = SCORE_TOTAL;
    }

    public Record ()
    {

    }
    }

