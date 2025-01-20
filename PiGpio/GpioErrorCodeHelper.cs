using System;
using System.ComponentModel;

namespace RaspberryDotNetLedBlink.PiGpio;

public static class GpioErrorCodeHelper
{

    /// <summary>
    /// Returns a description of GPIO error code
    /// </summary>
    public static string GetPgioErrorDescription(this int errorCode)
    {
        try
        {
            var enumType = typeof(GpioErrorCode);
            var error = (GpioErrorCode)errorCode;
            var memberInfos = enumType.GetMember(error.ToString());
            var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
            var valueAttributes = enumValueMemberInfo!.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return ((DescriptionAttribute)valueAttributes[0]).Description;
        }
        catch
        {
            return $"unknown error code {errorCode}";
        }
    }
}
