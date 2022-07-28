using UnityEngine ;
using UnityEngine.UI ;
using UnityEngine.Events ;
using System.Collections ;
using TMPro;

public class Timer : MonoBehaviour {

   [SerializeField] private TextMeshProUGUI uiText ;

   public int Duration { get; private set; }

   private int remainingDuration;

    public int MaxDuration;
   // Events --
   private UnityAction onTimerBeginAction ;
   private UnityAction<int> onTimerChangeAction ;
   private UnityAction onTimerEndAction ;

   private void Awake () {
      ResetTimer () ;
   }

   public void ResetTimer () {
      uiText.text = "00:00" ;
        StopAllCoroutines();
      Duration = remainingDuration = 0 ;

      onTimerBeginAction = null ;
      onTimerChangeAction = null ;
      onTimerEndAction = null ;
   }


   public Timer SetDuration (int seconds) {
      Duration = remainingDuration = seconds ;
      return this ;
   }

   public Timer OnBegin (UnityAction action) {
      onTimerBeginAction = action ;
      return this ;
   }

   public Timer OnChange (UnityAction<int> action) {
      onTimerChangeAction = action ;
      return this ;
   }

   public Timer OnEnd (UnityAction action) {
      onTimerEndAction = action ;
      return this ;
   }

    public Timer SetRemainDuration(int seconds)
    {
        remainingDuration = seconds;
        return this;
    }



    public void Begin () {
      if (onTimerBeginAction != null)
         onTimerBeginAction.Invoke () ;

      StopAllCoroutines () ;
      StartCoroutine (UpdateTimer ()) ;
   }

   private IEnumerator UpdateTimer () {
      while (remainingDuration < MaxDuration) {
            if (onTimerChangeAction != null)
                onTimerChangeAction.Invoke(remainingDuration);

            UpdateUI(remainingDuration);
            remainingDuration++;
            yield return new WaitForSeconds (1f) ;
      }
      End () ;
   }

    public void BeginBack()
    {
        if (onTimerBeginAction != null)
            onTimerBeginAction.Invoke();

        StopAllCoroutines();
        StartCoroutine(UpdateTimerBack());
    }

    private IEnumerator UpdateTimerBack()
    {
        while (remainingDuration > 0)
        {
            if (onTimerChangeAction != null)
                onTimerChangeAction.Invoke(remainingDuration);

            UpdateUI(remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
        End();
    }

    private void UpdateUI (int seconds) {
      uiText.text = string.Format ("{0:D2}:{1:D2}", seconds / 60, seconds % 60) ;
   }

   public void End () {
      if (onTimerEndAction != null)
         onTimerEndAction.Invoke () ;
   }


   private void OnDestroy () {
      StopAllCoroutines () ;
   }
}
