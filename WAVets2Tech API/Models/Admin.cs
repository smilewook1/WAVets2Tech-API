using System;
using System.Collections.Generic;

namespace WAVets2Tech_API.Models;

/// <summary>
/// IMPORTANT: Read the description of the column &quot;control_level.&quot; References to this table in code must ALWAYS account for the value of &quot;control_level&quot; to prevent security issues.
/// 
/// Stores information on administrator accounts. Less thorough than the other two account types, because not as much is necessary.
/// </summary>
public partial class Admin
{
    /// <summary>
    /// A unique identifier to distinguish this from all other entries in the same table. Automatically generates when the record is created.
    /// 
    /// VERY IMPORTANT: There WILL be overlap between the internal IDs of this table and the internal IDs of other tables; this does NOT mean the two records are correlated in any way! Please use the foreign key columns when associating records of one table to records of another.
    /// </summary>
    public int InternalId { get; set; }

    /// <summary>
    /// The real first name of the staff member behind this account.
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// The real last name of the staff member behind this account.
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// The (business) email address of the staff member behind this account.
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Used to store the password hash (not the password itself) of the account. May or may not be used, depending on how we choose to do authentication.
    /// </summary>
    public string? PasswordHash { get; set; }

    /// <summary>
    /// Business phone number of the staff member behind this account.
    /// </summary>
    public int? Phone { get; set; }

    /// <summary>
    /// Mailbox address of the staff member behind this account.
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// A short to medium-length description with any additional, important information. Max 4000 characters, but probably won&apos;t need that much.
    /// </summary>
    public string? About { get; set; }

    /// <summary>
    /// Serves as an enumerable to determine how much access/permissions the admin account has. The higher the number, the greater the permissions. As of writing, the current tiers have yet to be decided.
    /// </summary>
    public int ControlLevel { get; set; }

    /// <summary>
    /// Optional field intended to store a picture of the admin. May or may not be used, though - including it just in case.
    /// 
    /// IMPORTANT: This can TECHNICALLY store other types of files as well. Make sure when coding the forms, to put a restriction so that only certain image file formats/sizes can be uploaded to the database!
    /// </summary>
    public byte[]? ProfilePicture { get; set; }

    public virtual ICollection<HelpRequest> HelpRequests { get; } = new List<HelpRequest>();

    public virtual ICollection<Preference> Preferences { get; } = new List<Preference>();
}
