# TrashMailDomainDetector
This is a solution to check whether an email domain originates from a trashmail server

### Note: This made [@Dalk-Github](https://github.com/Dalk-Github) for my game hosting panel project ###

## Example ##
```csharp
public void Example()
{
  if(TrashMailDomainDetector.IsTrashMail("test@mailnesia.com")
  {
    Console.WriteLine("This is an email address hosted by a trashmail provider");
  }
  else
  {
    Console.WriteLine("This email domain is valid");
  }
}
```
## Other things ###

If you want to add domains to the list, please make a pull request

See the list [here](https://github.com/Marcel-Baumgartner/TrashMailDomainDetector/blob/main/trashmail_domains.md)
