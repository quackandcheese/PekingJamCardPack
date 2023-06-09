﻿using ModdingUtils.Extensions;
using ModdingUtils.MonoBehaviours;
using UnboundLib;
using UnityEngine;

namespace ModdingUtils.RoundsEffects
{
    public class GravityDealtDamageEffect : HitEffect // Do not trigger on DamageOverTime
    {
        public override void DealtDamage(Vector2 damage, bool selfDamage, Player damagedPlayer = null)
        {
            if (damagedPlayer == null) { return; }

            GravityEffect thisGravityEffect = damagedPlayer.gameObject.GetOrAddComponent<GravityEffect>();
            thisGravityEffect.SetDuration(this.GetComponent<CharacterStatModifiers>().GetAdditionalData().gravityDurationOnDoDamage);
            thisGravityEffect.SetGravityForceMultiplier(this.GetComponent<CharacterStatModifiers>().GetAdditionalData().gravityMultiplierOnDoDamage);
            thisGravityEffect.ResetTimer();

            // if this inflicts negative gravity, kick the player off the ground
            if (this.GetComponent<CharacterStatModifiers>().GetAdditionalData().gravityMultiplierOnDoDamage < 0f && damagedPlayer.data.isGrounded)
            {
                damagedPlayer.data.jump.Jump(true, 1f/damagedPlayer.data.stats.jump);
                damagedPlayer.data.currentJumps++;
            }
        }
    }
}