// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osuTK;
using osu.Game.Beatmaps.Timing;

namespace osu.Game.Beatmaps.ControlPoints
{
    public class TimingControlPoint : ControlPoint
    {
        /// <summary>
        /// The time signature at this control point.
        /// </summary>
        public TimeSignatures TimeSignature = TimeSignatures.SimpleQuadruple;

        public const double DEFAULT_BEAT_LENGTH = 1000;

        /// <summary>
        /// The beat length at this control point.
        /// </summary>
        public virtual double BeatLength
        {
            get => beatLength;
            set => beatLength = MathHelper.Clamp(value, 6, 60000);
        }

        /// <summary>
        /// The BPM at this control point.
        /// </summary>
        public double BPM => 60000 / BeatLength;

        private double beatLength = DEFAULT_BEAT_LENGTH;

        public override bool EquivalentTo(ControlPoint other) =>
            other is TimingControlPoint otherTyped
            && TimeSignature == otherTyped.TimeSignature && beatLength.Equals(otherTyped.beatLength);
    }
}
