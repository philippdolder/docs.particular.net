﻿using NServiceBus;
using NServiceBus.Hosting.Profiles;

#region dependent_profile
class MyProfileHandler : IHandleProfile<MyProfile>
{
    public void ProfileActivated(BusConfiguration busConfiguration)
    {
        // set something else in the container
    }

    public void ProfileActivated(Configure config)
    {
    }
}
#endregion

internal class MyProfile : IProfile
{
}