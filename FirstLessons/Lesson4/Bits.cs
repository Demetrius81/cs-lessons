
using System.ComponentModel.DataAnnotations;

namespace Lesson4;
internal class Bits : IBits
{
    private readonly int max;
    public long Value { get; set; }

    public Bits(byte value)
    {
        Value = value;
        max = 7;
    }

    public Bits(short value)
    {
        Value = value;
        max = 15;
    }

    public Bits(int value)
    {
        Value = value;
        max = 31;
    }

    public Bits(long value)
    {
        Value = value;
        max = 63;
    }


    #region indexator

    public bool this[int index]
    {
        get
        {
            if (index < 0 || index > max)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return ((Value >> index) & 1) == 1;
        }
        set
        {
            if (index < 0 || index > max)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            if (value)
            {
                Value |= (long)(1 << index);
            }
            else
            {
                var mask = (long)(1 << index);
                mask = 0xff ^ mask;
                Value &= mask;
            }
        }
    }

    #endregion

    public bool GetBit(int index)
    {
        if (index < 0 || index > max)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        return ((Value >> index) & 1) == 1;
    }

    public void SetBit(bool value, int index)
    {
        if (index < 0 || index > max)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        if (value)
        {
            Value |= (long)(1 << index);
        }
        else
        {
            var mask = (long)(1 << index);
            mask = 0xff ^ mask;
            Value &= mask;
        }
    }
}
