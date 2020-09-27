[System.Serializable]
public class Character {
    public string Name;
    public float JumpSquad;
    public float SoftLanding;
    public float HardLanding;
    public float InitialDash;
    public float SingleDash;
    public float Weight;
    public float WalkSpeed;
    public float RunSpeed;
    public float AirSpeed;
    public float FallSpeed;
    public float FastFallSpeed;
    public float ShortHopTime;
    public float FullHopTime;
    public float ShortHopFastFallTime;
    public float FullHopFastFallTime;

    public float GetStat ( Stats stat ) {
        switch ( stat ) {
            case Stats.JumpSquad:
                return JumpSquad;
            case Stats.SoftLanding:
                return SoftLanding;
            case Stats.HardLanding:
                return HardLanding;
            case Stats.InitialDash:
                return InitialDash;
            case Stats.SingleDash:
                return SingleDash;
            case Stats.Weight:
                return Weight;
            case Stats.WalkSpeed:
                return WalkSpeed;
            case Stats.RunSpeed:
                return RunSpeed;
            case Stats.AirSpeed:
                return AirSpeed;
            case Stats.FallSpeed:
                return FallSpeed;
            case Stats.FastFallSpeed:
                return FastFallSpeed;
            case Stats.ShortHopTime:
                return ShortHopTime;
            case Stats.FullHopTime:
                return FullHopTime;
            case Stats.ShortHopFastFallTime:
                return ShortHopFastFallTime;
            case Stats.FullHopFastFallTime:
                return FullHopFastFallTime;
        }
        return -1;
    }
}

public enum Stats {
    JumpSquad, SoftLanding, HardLanding, InitialDash, SingleDash, Weight, WalkSpeed, RunSpeed, AirSpeed, FallSpeed, FastFallSpeed, ShortHopTime, FullHopTime, ShortHopFastFallTime, FullHopFastFallTime
}